//
//SpingManager.cs for unity-chan!
//
//Original Script is here:
//ricopin / SpingManager.cs
//Rocket Jump : http://rocketjump.skr.jp/unity3d/109/
//https://twitter.com/ricopin416
//
//Revised by N.Kobayashi 2014/06/24
//           Y.Ebata
//
using UnityEngine;
using System.Collections;

namespace UnityChan
{
	public class SpringManager : MonoBehaviour
	{
		//Kobayashi
		// DynamicRatio is paramater for activated level of dynamic animation 
		public float dynamicRatio = 1.0f;

		//Ebata
		public float			stiffnessForce;
		public AnimationCurve	stiffnessCurve;
		public float			dragForce;
		public AnimationCurve	dragCurve;
		public SpringBone[] springBones;
		public SpringCollider[] colliders;

		void Start ()
		{
			UpdateParameters ();
		}
	
		void Update ()
		{
#if UNITY_EDITOR
		//Kobayashi
		if(dynamicRatio >= 1.0f)
			dynamicRatio = 1.0f;
		else if(dynamicRatio <= 0.0f)
			dynamicRatio = 0.0f;
		//Ebata
		UpdateParameters();
#endif
		}
	
		private void LateUpdate ()
		{
			//Kobayashi
			if (dynamicRatio != 0.0f) {
				for (int i = 0; i < springBones.Length; i++) {
					if (dynamicRatio > springBones [i].threshold) {
						springBones [i].UpdateSpring ();
					}
				}
			}
		}
		[ContextMenu("rigging")]
		public void GetEveryBones(){
			Transform[] transforms= GetComponentsInChildren<Transform>();
			foreach(Transform i in transforms){
				if(i.name.StartsWith("J_")){
					if(i.childCount>0){
						i.gameObject.AddComponent<SpringBone>();
						i.gameObject.GetComponent<SpringBone>().child =i.GetChild(0);
						i.gameObject.GetComponent<SpringBone>().boneAxis =new Vector3(0,1,0);
					}
				}
			}
			springBones = GetComponentsInChildren<SpringBone>();
		}
		[ContextMenu("remove rigging")]
		public void RemoveAllSpringBones() {
    		// 获取当前游戏对象及其所有子对象的Transform组件
			Transform[] transforms = GetComponentsInChildren<Transform>();

			// 遍历所有Transform组件
			foreach(Transform t in transforms) {
			// 检查游戏对象的名称是否以"PJ_"或"Q_"开头
				if(t.name.StartsWith("J_") ) {
				// 如果是，获取该游戏对象上所有的SpringBone组件
					SpringBone[] springBones = t.GetComponentsInChildren<SpringBone>();
				// 遍历所有SpringBone组件，并逐一销毁
					foreach(SpringBone sb in springBones) {
					// 销毁SpringBone组件
						DestroyImmediate(sb);
					}
				}
			}
		}
	
		private void UpdateParameters ()
		{
			UpdateParameter ("stiffnessForce", stiffnessForce, stiffnessCurve);
			UpdateParameter ("dragForce", dragForce, dragCurve);
		}
	
		private void UpdateParameter (string fieldName, float baseValue, AnimationCurve curve)
		{
			var start = curve.keys [0].time;
			var end = curve.keys [curve.length - 1].time;
			//var step	= (end - start) / (springBones.Length - 1);
		
			var prop = springBones [0].GetType ().GetField (fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
		
			for (int i = 0; i < springBones.Length; i++) {
				//Kobayashi
				if (!springBones [i].isUseEachBoneForceSettings) {
					var scale = curve.Evaluate (start + (end - start) * i / (springBones.Length - 1));
					prop.SetValue (springBones [i], baseValue * scale);
				}
			}
		}
	}
}
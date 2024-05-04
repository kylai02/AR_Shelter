using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat_manager : MonoBehaviour
{
    Animator animator;
    public bool isIkactivated;
    public Transform objTransform;
    private float lookatWeight;
    public float lookatDistance;

    GameObject objPivot;

    // Start is called before the first frame update
    void Start()
    {
        //default setting
        lookatDistance = 5f;
        isIkactivated = true;
        animator = GetComponent<Animator>();
        
        //generate pivot
        objPivot = new GameObject("basePivot");
        objPivot.transform.parent = transform;
        objPivot.transform.localPosition = new Vector3(0, 1.41f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        objPivot.transform.LookAt(objTransform);
        float objPivotRot = objPivot.transform.localRotation.y;
        //Debug.Log(objPivotRot);
        float objPivotDist = Vector3.Distance(objPivot.transform.position, objTransform.transform.position);
        //Debug.Log(objPivotDist);

        if (objPivotRot > -0.65f && objPivotRot < 0.65f && objPivotDist < lookatDistance)
        {
            //target lockon
            lookatWeight = Mathf.Lerp(lookatWeight, 1f, Time.deltaTime * 2.5f);
        }
        else
        {
            //target release
            lookatWeight = Mathf.Lerp(lookatWeight, 0f, Time.deltaTime * 2.5f);
        }
    }

    private void OnAnimatorIK()
    {
        if (animator != null)
        {
            if (isIkactivated)
            {
                if (objTransform != null)
                {
                    animator.SetLookAtWeight(lookatWeight);
                    animator.SetLookAtPosition(objTransform.position);
                }
            }
            else
            {
                animator.SetLookAtWeight(0);
            }
        }
    }
}

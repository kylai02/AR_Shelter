using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShakeEffect : MonoBehaviour {
  [SerializeField] private float shakePeriod = 0.02f;
  [SerializeField] private float shakeAmount = 0.1f;

  private Vector3 initPos;
  private int times;

  public void StartShaking(float shakeTime) {
    initPos = transform.localPosition;
    times = (int)(shakeTime / shakePeriod);
    SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, shakeTime, 30, 10);
    SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, shakeTime, 30, 10);

    StartCoroutine(ShakeRoutine());
  }

  IEnumerator ShakeRoutine() {
    for (int i = 0; i < times; ++i) {
      Vector3 shakePos = initPos + Random.insideUnitSphere * shakeAmount;
      shakePos.x = initPos.x;
      // shakePos.y = initPos.y;

      transform.localPosition = shakePos;
      yield return new WaitForSeconds(shakePeriod);
    }

    transform.localPosition = initPos;
    yield return new WaitForEndOfFrame();
  }
}

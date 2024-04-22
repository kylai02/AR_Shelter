using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShakeEffect : MonoBehaviour {
  [SerializeField] private float shakeTime = 5f;
  [SerializeField] private float shakePeriod = 0.2f;
  [SerializeField] private float shakeAmount = 0.1f;

  private Vector3 initPos;
  private int times;

  void Start() {
    initPos = transform.localPosition;
    times = (int)(shakeTime / shakePeriod);
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.I)) {
      StartCoroutine(StartShake());
    }
    else {
      transform.localPosition = initPos;
    }
  }

  IEnumerator StartShake() {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class WateringCan : MonoBehaviour {
  void Update() {
    float rotateAngle = WrapAngle(transform.localEulerAngles.z);
    if (rotateAngle < -45) {
      Debug.Log("Drop");
    }
    else {
      Debug.Log("Hold");
    }
  }

  private float WrapAngle(float angle) {
    angle %= 360;
    if (angle > 180) {
      return angle - 360;
    }

    return angle;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class WateringCan : MonoBehaviour {
  void Update() {
    float rotateAngle = WrapAngle(transform.localEulerAngles.z);
    if (rotateAngle < -45) {
      Debug.Log("Drop");
      // TODO: Trigger the watering effect
    }
    else {
      Debug.Log("Hold");
    }
  }

  // Convert the transform's eulerAngles to the form of the inspector
  private float WrapAngle(float angle) {
    angle %= 360;
    if (angle > 180) {
      return angle - 360;
    }
    return angle;
  }
}

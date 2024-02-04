using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sprinkler : MonoBehaviour {
  void Update() {
    float rotateAngle = transform.eulerAngles.x;
    if (rotateAngle > 45) {
      Debug.Log("Drop");
    }
    else {
      Debug.Log("No");
    }
  }
}

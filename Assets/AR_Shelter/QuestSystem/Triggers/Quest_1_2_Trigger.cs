using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Quest_1_2_Trigger : MonoBehaviour {
  public bool isTriggered = false;

  private void OnTriggerEnter(Collider other) {
    if (!isTriggered) {
      isTriggered = true;
    }
  }
}

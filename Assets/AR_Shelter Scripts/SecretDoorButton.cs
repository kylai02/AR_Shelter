using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class SecretDoorButton : MonoBehaviour {
  public void OnButtonDown(Hand fromHand) {
    Debug.Log("Down");
    fromHand.TriggerHapticPulse(1000);
  }

  public void OnButtonUp(Hand fromHand) {
    Debug.Log("Up");
  }
}

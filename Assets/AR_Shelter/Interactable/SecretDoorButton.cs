using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using DG.Tweening;


public class SecretDoorButton : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject secretDoorObj;

  private bool isOpen = false;

  public void OnButtonDown(Hand fromHand) {
    // Trigger haptic on controller
    fromHand.TriggerHapticPulse(1000);
    
    if (!isOpen) {

      // Open the secret door
      secretDoorObj.transform.DORotate(
        endValue: new Vector3(0, 80, 0), 
        duration: 2, 
        mode: RotateMode.WorldAxisAdd
      );

      // Close the collider of the door
      secretDoorObj.GetComponent<Collider>().enabled = false;

      isOpen = true;
    }
  }

  public void OnButtonUp(Hand fromHand) {}
}

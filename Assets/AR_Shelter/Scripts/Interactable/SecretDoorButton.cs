using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using DG.Tweening;


public class SecretDoorButton : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject _secretDoorObj;

  private bool _isOpen = false;

  public void OnButtonDown(Hand fromHand) {
    // Trigger haptic on controller
    fromHand.TriggerHapticPulse(1000);
    
    if (!_isOpen) {

      // Open the secret door
      _secretDoorObj.transform.DORotate(
        endValue: new Vector3(0, 80, 0), 
        duration: 2, 
        mode: RotateMode.WorldAxisAdd
      );

      // Close the collider of the door
      _secretDoorObj.GetComponent<Collider>().enabled = false;

      _isOpen = true;
    }
  }

  public void OnButtonUp(Hand fromHand) {}
}

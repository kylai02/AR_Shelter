using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenDoor : MonoBehaviour {
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private int openAngle;
  [SerializeField] private float duration;
  [SerializeField] private bool antiClockRotate;

  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private Collider _doorCollider;
  [SerializeField] private Collider _handleTrigger;

  // Touch the trigger to open the door
  private void OnTriggerEnter(Collider other) {
    int angle = openAngle * (antiClockRotate ? -1 : 1);

    // TODO: Determine if the collider is a hand
    if (true) {
      transform.DORotate(
        endValue: new Vector3(0, angle, 0), 
        duration: duration, 
        mode: RotateMode.WorldAxisAdd
      );

      _doorCollider.enabled = false;
      _handleTrigger.enabled = false;
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenDoubleDoor : MonoBehaviour {
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private int openAngle;
  [SerializeField] private float duration;

  [HeaderAttribute("References")]
  [SpaceAttribute(10)]
  [SerializeField] private GameObject antiClockwiseDoor;
  [SerializeField] private GameObject clockwiseDoor;
  [SerializeField] private Collider handleTrigger;

  // Touch the trigger to open the door
  private void OnTriggerEnter(Collider other) {
    // TODO: Determine if the collider is a hand
    if (true) {
      antiClockwiseDoor.transform.DORotate(
        endValue: new Vector3(0, -1 * openAngle, 0), 
        duration: duration, 
        mode: RotateMode.WorldAxisAdd
      );

      clockwiseDoor.transform.DORotate(
        endValue: new Vector3(0, openAngle, 0), 
        duration: duration, 
        mode: RotateMode.WorldAxisAdd
      );

      handleTrigger.enabled = false;
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenDoubleDoor : MonoBehaviour {
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(10)]
  public int openAngle;
  public float duration;

  [HeaderAttribute("References")]
  [SpaceAttribute(10)]
  public GameObject antiClockwiseDoor;
  public GameObject clockwiseDoor;
  public Collider handleTrigger;

  private void OnTriggerEnter(Collider other) {
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

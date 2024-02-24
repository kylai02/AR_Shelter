using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenDoor : MonoBehaviour {
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(10)]
  public int openAngle;
  public float duration;
  public bool antiClockRotate;

  [HeaderAttribute("References")]
  [SpaceAttribute(10)]
  public Collider doorCollider;
  public Collider handleTrigger;

  private void OnTriggerEnter(Collider other) {
    int angle = openAngle * (antiClockRotate ? -1 : 1);

    if (true) {
      transform.DORotate(
        endValue: new Vector3(0, angle, 0), 
        duration: duration, 
        mode: RotateMode.WorldAxisAdd
      );

      doorCollider.enabled = false;
      handleTrigger.enabled = false;
    }
  }
}

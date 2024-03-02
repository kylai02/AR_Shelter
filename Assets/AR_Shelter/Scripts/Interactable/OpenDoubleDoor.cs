using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenDoubleDoor : MonoBehaviour {
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private int _openAngle;
  [SerializeField] private float _duration;

  [HeaderAttribute("References")]
  [SpaceAttribute(10)]
  [SerializeField] private GameObject _antiClockwiseDoor;
  [SerializeField] private GameObject _clockwiseDoor;
  [SerializeField] private Collider _handleTrigger;

  // Touch the trigger to open the door
  private void OnTriggerEnter(Collider other) {
    // TODO: Determine if the collider is a hand
    if (true) {
      _antiClockwiseDoor.transform.DORotate(
        endValue: new Vector3(0, -1 * _openAngle, 0), 
        duration: _duration, 
        mode: RotateMode.WorldAxisAdd
      );

      _clockwiseDoor.transform.DORotate(
        endValue: new Vector3(0, _openAngle, 0), 
        duration: _duration, 
        mode: RotateMode.WorldAxisAdd
      );

      _handleTrigger.enabled = false;
    }
  }
}

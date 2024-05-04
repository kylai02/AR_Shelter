using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


public class OpenDoor : MonoBehaviour {
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private int openAngle;
  [SerializeField] private float duration;
  [SerializeField] private bool antiClockRotate;

  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private Collider doorCollider;
  [SerializeField] private Collider handleTrigger;
  [SerializeField] private GameObject teleportPointParent;

  public bool isOpen = false;

  private AudioSource audioSource;
  
  void Awake() {
    audioSource = gameObject.GetComponent<AudioSource>();
  }

  // Touch the trigger to open the door
  private void OnTriggerEnter(Collider other) {
    int angle = openAngle * (antiClockRotate ? -1 : 1);

    // TODO: Determine if the collider is a hand
    if (true) {
      audioSource.Play();
      transform.DORotate(
        endValue: new Vector3(0, angle, 0), 
        duration: duration, 
        mode: RotateMode.WorldAxisAdd
      );

      doorCollider.enabled = false;
      handleTrigger.enabled = false;
      teleportPointParent.SetActive(false);

      isOpen = true;
    }
  }
}

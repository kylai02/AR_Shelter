using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
  public Animator animator;

  private void OnCollisionEnter(Collision other) {
    animator.SetTrigger("Open");
  }
}

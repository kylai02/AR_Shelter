using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HarukaAnimationController : MonoBehaviour {
  private Animator animator;

  void Start() {
    animator = GetComponent<Animator>();
  }

  public void SetFaceStatement(int index) {
    animator.SetInteger("Face_statement", index);
  }

  public void SetMovement(int index) {
    animator.SetInteger("Movement", index);
  }
}

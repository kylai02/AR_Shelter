using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationTrigger : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private PlayAnimation playAnimation;
  
  private bool isTriggered = false;

  private void OnTriggerEnter(Collider other) {
    if (!isTriggered) {
      isTriggered = true;
      StartCoroutine(AnimationRoutine());
    }
  }

  IEnumerator AnimationRoutine() {
    yield return new WaitForSeconds(1f);

    playAnimation.PlayAnimationObj();
  }
}

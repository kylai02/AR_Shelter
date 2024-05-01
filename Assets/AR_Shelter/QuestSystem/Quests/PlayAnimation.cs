using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAnimation : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject targetEffect;
  [SerializeField] private GameObject roadEffect;
  [SerializeField] private GameObject animationObj;

  private bool hasPlayed = false;
  private bool canPlay = false;

  void Awake() {
    Quest_2_2.MemoryStartEvent += CanPlayAnimation;
  }

  void OnDisable() {
    Quest_2_2.MemoryStartEvent -= CanPlayAnimation;
  }

  public void PlayAnimationObj() {
    if (!hasPlayed && canPlay) {
      hasPlayed = true;
      targetEffect?.SetActive(false);
      if (roadEffect != null) {
        roadEffect?.SetActive(true);
      }
      animationObj?.SetActive(true);
      StartCoroutine(AnimationRoutine());
    }
  }

  private void CanPlayAnimation() {
    targetEffect?.SetActive(true);
    canPlay = true;
  }

  IEnumerator AnimationRoutine() {
    yield return new WaitForSeconds(11f);
    animationObj.SetActive(false);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAnimation : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject targetEffect;
  [SerializeField] private GameObject roadEffect;
  [SerializeField] private GameObject animationObj;
  
  [Header("Settings")]
  [Space(3)]
  [SerializeField] private string bgmName;

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
    AudioManager.instance.FadeOut("BGM", true);
    yield return new WaitForSeconds(2f);

    if (bgmName != "") {
      AudioManager.instance.FadeIn(bgmName, false);
    }

    yield return new WaitForSeconds(8f);

    if (bgmName != "") {
      AudioManager.instance.FadeOut(bgmName, false);
    }
    yield return new WaitForSeconds(2f);

    AudioManager.instance.FadeIn("BGM", true);
    animationObj.SetActive(false);
  }
}

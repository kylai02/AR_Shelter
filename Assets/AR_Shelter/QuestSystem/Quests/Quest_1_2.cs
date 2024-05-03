using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_2 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private HarukaAnimationController harukaAnimationController;
  [SerializeField] private Quest_1_2_Trigger trigger;
  [SerializeField] private GameObject plateRoadEffect;
  [SerializeField] private GameObject kitchenAnimation;

  private bool hasPlayed = false;
  private bool canPlay = false;

  protected override void StartQuest() {
    StartCoroutine(QuestCoroutine());
  }

  public void CanPlayAnimation() {
    canPlay = true;
  }

  public void PlayAnimation() {
    if (!hasPlayed && canPlay) {
      hasPlayed = true;
      plateRoadEffect.SetActive(true);
      kitchenAnimation.SetActive(true);
    }
  }

  IEnumerator QuestCoroutine() {
    harukaAnimationController.SetFaceStatement(23);
    harukaAnimationController.SetMovement(2);

    yield return new WaitForSeconds(3f);

    harukaAnimationController.SetFaceStatement(1);
    harukaAnimationController.SetMovement(1);

    yield return new WaitUntil(() => trigger.isTriggered);
    yield return new WaitForSeconds(1f);

    StartDialogues();

    yield return new WaitUntil(() => hasPlayed);

    AudioManager.instance.FadeIn("Frying", false);
    AudioManager.instance.FadeIn("Verse", false);
    yield return new WaitForSeconds(8f);
    AudioManager.instance.FadeOut("Frying", false);
    AudioManager.instance.FadeOut("Verse", false);
    yield return new WaitForSeconds(2f);

    kitchenAnimation.SetActive(false);
    AudioManager.instance.FadeIn("BGM", true);

    NextQuest();
    gameObject.SetActive(false);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_5 : Quest {
  [HeaderAttribute("Dialogues After Animation")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueAfterAnimationStrings = new();

  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject wateringCanRoadEffect;
  [SerializeField] private GameObject gardenAnimation;

  private bool hasPlayed = false;
  private bool canPlay = false;

  protected override void StartQuest() {
    StartDialogues();
  }

  public void WaitUntilAnimationComplete() {
    StartCoroutine(QuestCoroutine());
  }

  public void CanPlayAnimation() {
    canPlay = true;
  }

  public void PlayAnimation() {
    if (!hasPlayed && canPlay) {
      hasPlayed = true;
      wateringCanRoadEffect.SetActive(true);
      gardenAnimation.SetActive(true);
    }
  }

  IEnumerator QuestCoroutine() {
    // TODO: WaitUntil Animation is over
    yield return new WaitUntil(() => hasPlayed);
    yield return new WaitForSeconds(10);

    gardenAnimation.SetActive(false);

    DialogueManager.instance.DialogueStart(dialogueAfterAnimationStrings);
  }
}

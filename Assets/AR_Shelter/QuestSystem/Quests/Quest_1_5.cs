using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_5 : Quest {
  [HeaderAttribute("Dialogues After Animation")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueAfterAnimationStrings = new();

  protected override void StartQuest() {
    StartDialogues();
  }

  public void WaitUntilAnimationComplete() {
    StartCoroutine(QuestCoroutine());
  }

  IEnumerator QuestCoroutine() {
    // TODO: WaitUntil Animation is over
    yield return new WaitForSeconds(5f);

    DialogueManager.instance.DialogueStart(dialogueAfterAnimationStrings);
  }
}

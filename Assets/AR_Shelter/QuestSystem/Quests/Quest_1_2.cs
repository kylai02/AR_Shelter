using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_2 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private HarukaAnimationController harukaAnimationController;
  [SerializeField] private Quest_1_2_Trigger trigger;

  protected override void StartQuest() {
    StartCoroutine(QuestCoroutine());
  }

  public void SkipToNextQuestForDebug() {
    Invoke("NextQuest", 5f);
  }

  IEnumerator QuestCoroutine() {
    harukaAnimationController.SetFaceStatement(23);
    harukaAnimationController.SetMovement(2);

    yield return new WaitForSeconds(3f);

    harukaAnimationController.SetFaceStatement(1);
    harukaAnimationController.SetMovement(1);

    yield return new WaitUntil(() => trigger.isTriggered);

    StartDialogues();
  }
}

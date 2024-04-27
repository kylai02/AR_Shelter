using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_2_2 : Quest {
  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  IEnumerator QuestRoutine() {
    yield return new WaitForSeconds(300f);
    
    StartDialogues();
  }
}

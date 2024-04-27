using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_2_2 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private ShakeEffect shakeEffect;

  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private float waitForSeconds = 300f;
  [SerializeField] private float shakeTime = 60f;

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  IEnumerator QuestRoutine() {
    yield return new WaitForSeconds(waitForSeconds);
    
    shakeEffect.StartShaking(60f);

    yield return new WaitForSeconds(3f);
    
    StartDialogues();
  }
}

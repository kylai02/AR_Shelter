using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_2_2 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private ShakeEffect shakeEffect;
  [SerializeField] private GameObject wardDoorEffect;
  [SerializeField] private OpenDoor wardDoor;

  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private float waitForSeconds = 300f;
  [SerializeField] private float shakeTime = 60f;

  public static event Action MemoryStartEvent;

  void Update() {
    if (wardDoor.isOpen) {
      wardDoorEffect.SetActive(false);
    }
  }

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  IEnumerator QuestRoutine() {
    MemoryStartEvent?.Invoke();

    // DEBUG
    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
    // yield return new WaitForSeconds(waitForSeconds);
    
    shakeEffect.StartShaking(60f);

    yield return new WaitForSeconds(3f);
    
    StartDialogues();
  }
}

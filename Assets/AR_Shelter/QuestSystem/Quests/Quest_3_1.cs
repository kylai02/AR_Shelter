using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_3_1 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject door;

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  IEnumerator QuestRoutine() {
    OpenDoor openDoor = door.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);
    yield return new WaitForSeconds(2f);

    StartDialogues();
  }
}

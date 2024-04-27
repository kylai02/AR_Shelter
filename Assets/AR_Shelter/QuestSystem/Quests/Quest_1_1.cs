using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_1 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject door;
  [SerializeField] private GameObject doorTargetEffect;

  protected override void StartQuest() {
    StartDialogues();
  }


  public void StartWaitUntilDoorOpen() {
    StartCoroutine(WaitUntilDoorOpen());
  }

  IEnumerator WaitUntilDoorOpen() {
    OpenDoor openDoor = door.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);

    doorTargetEffect.SetActive(false);

    NextQuest();
    gameObject.SetActive(false);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_3 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject door;
  [SerializeField] private GameObject doorTargetEffect;
  [SerializeField] private HarukaAnimationController harukaAnimationController;

  protected override void StartQuest() {
    StartDialogues();
  }

  public void StartWaitUntilDoorOpen() {
    StartCoroutine(WaitUntilDoorOpen());
  }

  IEnumerator WaitUntilDoorOpen() {
    yield return new WaitForSeconds(3f);

    harukaAnimationController.SetFaceStatement(3);
    harukaAnimationController.SetMovement(0);

    OpenDoor openDoor = door.GetComponent<OpenDoor>();

    yield return new WaitUntil(() => openDoor.isOpen);

    doorTargetEffect.SetActive(false);

    NextQuest();
    gameObject.SetActive(false);
  }
}

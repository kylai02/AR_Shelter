using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Quest_3_1 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject door;
  [SerializeField] private GameObject secretDoor;
  [SerializeField] private GameObject animationObj;
  [SerializeField] private GameObject glasses;

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  IEnumerator QuestRoutine() {
    OpenDoor openDoor = door.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);
    yield return new WaitForSeconds(2f);

    StartDialogues();

    openDoor = secretDoor.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);
    yield return new WaitForSeconds(2f);

    animationObj.SetActive(true);
    yield return new WaitForSeconds(10f);
    animationObj.SetActive(false);

    yield return new WaitForSeconds(1.5f);
    glasses.transform.DOLocalMoveY(0.4f, 4).SetEase(Ease.OutCubic);
  }
}

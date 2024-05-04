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
    AudioManager.instance.FadeIn("Wind", false);

    OpenDoor openDoor = door.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);
    yield return new WaitForSeconds(2f);

    StartDialogues();

    openDoor = secretDoor.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);
    yield return new WaitForSeconds(2f);

    AudioManager.instance.FadeOut("Wind", true);
    yield return new WaitForSeconds(2f);
    AudioManager.instance.FadeIn("Chrous", false);
    animationObj.SetActive(true);
    yield return new WaitForSeconds(7f);
    AudioManager.instance.FadeOut("Chrous", false);
    yield return new WaitForSeconds(2f);
    AudioManager.instance.FadeIn("Wind", true);

    animationObj.SetActive(false);

    yield return new WaitForSeconds(2f);
    glasses.transform.DOLocalMoveY(0.4f, 4).SetEase(Ease.OutCubic);
  }
}

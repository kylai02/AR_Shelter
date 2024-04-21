using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_1_4 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject door1;
  [SerializeField] private GameObject door2;
  [SerializeField] private GameObject door1TargetEffect;
  [SerializeField] private GameObject door2TargetEffect;

  protected override void StartQuest() {
    StartCoroutine(QuestCoroutine());
  }

  IEnumerator QuestCoroutine() {
    yield return new WaitForSeconds(3f);
    
    StartDialogues();

    OpenDoor openDoor1 = door1.GetComponent<OpenDoor>();
    OpenDoor openDoor2 = door2.GetComponent<OpenDoor>();

    yield return new WaitUntil(() => openDoor1.isOpen || openDoor2.isOpen);

    door1TargetEffect.SetActive(false);
    door2TargetEffect.SetActive(false);

    NextQuest();
    gameObject.SetActive(false);
  }
}

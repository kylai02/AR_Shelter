using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Quest_2_1 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject door;

  [HeaderAttribute("Dialogues After Door Opened")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueAfterDoorOpenedStrings = new();

  private bool memoryStarted = false;

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  public void StartMemory() {
    memoryStarted = true;
  }

  IEnumerator QuestRoutine() {
    yield return new WaitForSeconds(5f);

    StartDialogues();

    OpenDoor openDoor = door.GetComponent<OpenDoor>();
    yield return new WaitUntil(() => openDoor.isOpen);
    yield return new WaitForSeconds(3f);

    DialogueManager.instance.DialogueStart(dialogueAfterDoorOpenedStrings);

    yield return new WaitUntil(() => memoryStarted);

    NextQuest();
    gameObject.SetActive(false);
  }
}

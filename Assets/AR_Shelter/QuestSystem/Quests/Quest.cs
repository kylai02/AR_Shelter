using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


abstract public class Quest : MonoBehaviour {
  [HeaderAttribute("Dialogues")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueStrings = new();
  private bool hasSpoken = false;

  [HeaderAttribute("Attributes")]
  [SpaceAttribute(3)]
  [SerializeField] private string questId;

  void Awake() {
    QuestManager.QuestStartEvent += CheckStartQuest;
  }

  void OnDisable() {
    QuestManager.QuestStartEvent -= CheckStartQuest;
  }

  protected void StartDialogues() {
    if (!hasSpoken) {
      DialogueManager.instance.DialogueStart(dialogueStrings);
      hasSpoken = true;
    }
  }

  protected void CheckStartQuest(string questToStart) {
    if (questToStart == questId) {
      Debug.Log("Quest " + questId + " Start");
      StartQuest();
    }
  }

  protected void NextQuest() {
    Debug.Log("Quest " + questId + " Done");
    QuestManager.instance.StartNextQuest();
  }

  protected abstract void StartQuest();
}

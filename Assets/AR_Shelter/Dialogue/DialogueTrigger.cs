using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class DialogueTrigger : MonoBehaviour {
  [HeaderAttribute("Dialogues")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueStrings = new();

  private bool hasSpoken = false;

  private void OnTriggerEnter(Collider other) {
    if (!hasSpoken) {
      DialogueManager.instance.DialogueStart(dialogueStrings);
      hasSpoken = true;
    }
  }
}

[System.Serializable]
public class DialogueString {
  public string text;
  public string talker;
  public bool isEnd;
  
  [Header("Triggered Events")]
  public UnityEvent startDialogueEvent;
  public UnityEvent endDialogueEvent;
}

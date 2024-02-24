using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class DialogueTrigger : MonoBehaviour {
  [SerializeField] private List<DialogueString> dialogueStrings = new();

  private bool _hasSpoken = false;

  private void OnTriggerEnter(Collider other) {
    if (!_hasSpoken) {
      DialogueManager.instance.DialogueStart(dialogueStrings);
      _hasSpoken = true;
    }
  }
}

[System.Serializable]
public class DialogueString {
  public string text;
  public bool isEnd;
  
  [Header("Triggered Events")]
  public UnityEvent startDialogueEvent;
  public UnityEvent endDialogueEvent;
}

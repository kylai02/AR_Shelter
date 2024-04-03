using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitQuest : MonoBehaviour {
  [HeaderAttribute("Dialogues")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueStrings = new();

  [SerializeField] private float whenToStart = 5f;
  private bool hasSpoken = false;

  void Update() {
    whenToStart -= Time.deltaTime;

    if (!hasSpoken && whenToStart <= 0) {
      DialogueManager.instance.DialogueStart(dialogueStrings);
      hasSpoken = true;
    }
  }
}

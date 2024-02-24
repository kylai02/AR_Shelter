using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Valve.VR;


public class DialogueManager : MonoBehaviour {
  [SerializeField] private GameObject dialogueParent;
  [SerializeField] private TMP_Text dialogueText;
  [SerializeField] private float typingSpeed = 0.05f;

  [SerializeField] private SteamVR_Input_Sources steamVR_Input_Sources;

  public static DialogueManager instance;

  private List<DialogueString> _dialogueList;
  private int _currentDialogueIndex = 0;

  private SteamVR_Action_Boolean click = SteamVR_Input.GetBooleanAction("GrabPinch");

  void Start() {
    instance = this;
    dialogueParent.SetActive(false);
  }

  public void DialogueStart(List<DialogueString> textToPrint) {
    dialogueParent.SetActive(true);

    _dialogueList = textToPrint;
    _currentDialogueIndex = 0;

    StartCoroutine(PrintDialogue());
  }

  private IEnumerator PrintDialogue() {
    while (_currentDialogueIndex < _dialogueList.Count) {
      DialogueString line = _dialogueList[_currentDialogueIndex];

      line.startDialogueEvent?.Invoke();

      yield return StartCoroutine(TypeText(line.text));

      line.endDialogueEvent?.Invoke();
    }
  }

  private IEnumerator TypeText(string text) {
    dialogueText.text = "";
    foreach (char letter in text.ToCharArray()) {
      dialogueText.text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }

    yield return new WaitUntil(() => click.GetStateDown(steamVR_Input_Sources));

    if (_dialogueList[_currentDialogueIndex].isEnd) {
      DialogueStop();
    }

    _currentDialogueIndex++;
  }

  private void DialogueStop() {
    StopAllCoroutines();

    dialogueText.text = "";
    dialogueParent.SetActive(false);
  }
}

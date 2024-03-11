using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Valve.VR;


public class DialogueManager : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject _dialogueParent;
  [SerializeField] private TMP_Text _dialogueText;
  
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private float _typingSpeed = 0.05f;
  [SerializeField] private SteamVR_Input_Sources _steamVR_Input_Sources;

  // Singleton
  public static DialogueManager instance;

  private List<DialogueString> _dialogueList;
  private int _currentDialogueIndex = 0;

  // TODO: Make custom skip input action
  private readonly SteamVR_Action_Boolean _skip = 
    SteamVR_Input.GetBooleanAction("GrabPinch");

  void Start() {
    instance = this;
    _dialogueParent.SetActive(false);
  }

  public void DialogueStart(List<DialogueString> textToPrint) {
    _dialogueParent.SetActive(true);

    _dialogueList = textToPrint;
    _currentDialogueIndex = 0;

    StartCoroutine(PrintDialogue());
  }

  // Iterate through the sentences in the _dialogueList and print them out
  private IEnumerator PrintDialogue() {
    while (_currentDialogueIndex < _dialogueList.Count) {
      DialogueString line = _dialogueList[_currentDialogueIndex];

      line.startDialogueEvent?.Invoke();

      yield return StartCoroutine(TypeText(line.text));

      line.endDialogueEvent?.Invoke();
    }
  }

  // Typing effect
  private IEnumerator TypeText(string text) {
    _dialogueText.text = "";
    foreach (char letter in text.ToCharArray()) {
      _dialogueText.text += letter;
      yield return new WaitForSeconds(_typingSpeed);
    }

    // Switch to the next sentence only when "skip" inpout action is pressed
    yield return new WaitUntil(
      () => _skip.GetStateDown(_steamVR_Input_Sources)
    );

    if (_dialogueList[_currentDialogueIndex].isEnd) {
      DialogueStop();
    }

    _currentDialogueIndex++;
  }

  private void DialogueStop() {
    StopAllCoroutines();

    _dialogueText.text = "";
    _dialogueParent.SetActive(false);
  }
}

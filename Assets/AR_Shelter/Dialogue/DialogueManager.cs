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
  [SerializeField] private GameObject dialogueParent;
  [SerializeField] private TMP_Text dialogueText;
  
  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private float typingSpeed = 0.05f;
  [SerializeField] private SteamVR_Input_Sources steamVR_Input_Sources;

  // Singleton
  public static DialogueManager instance;

  private List<DialogueString> dialogueList;
  private int currentDialogueIndex = 0;

  // TODO: Make custom skip input action
  private readonly SteamVR_Action_Boolean skip = 
    SteamVR_Input.GetBooleanAction("GrabPinch");

  void Start() {
    instance = this;
    dialogueParent.SetActive(false);
  }

  public void DialogueStart(List<DialogueString> textToPrint) {
    dialogueParent.SetActive(true);

    dialogueList = textToPrint;
    currentDialogueIndex = 0;

    StartCoroutine(PrintDialogue());
  }

  // Iterate through the sentences in the _dialogueList and print them out
  private IEnumerator PrintDialogue() {
    while (currentDialogueIndex < dialogueList.Count) {
      DialogueString line = dialogueList[currentDialogueIndex];

      line.startDialogueEvent?.Invoke();

      yield return StartCoroutine(TypeText(line.text));

      line.endDialogueEvent?.Invoke();
    }
  }

  // Typing effect
  private IEnumerator TypeText(string text) {
    dialogueText.text = "";
    foreach (char letter in text.ToCharArray()) {
      dialogueText.text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }

    // Switch to the next sentence only when "skip" inpout action is pressed
    yield return new WaitUntil(
      () => skip.GetStateDown(steamVR_Input_Sources)
    );

    if (dialogueList[currentDialogueIndex].isEnd) {
      DialogueStop();
    }

    currentDialogueIndex++;
  }

  private void DialogueStop() {
    StopAllCoroutines();

    dialogueText.text = "";
    dialogueParent.SetActive(false);
  }
}

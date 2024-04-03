using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestOneTwo : MonoBehaviour {
  [SerializeField] private string questStep;
  [SerializeField] private Animator animator;

  [HeaderAttribute("Dialogues")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueStrings = new();
  [SerializeField] private List<DialogueString> dialogueStringsAfterKitchen = new();

  
  private bool hasStarted = false;
  private bool hasPlayed = false;

  void Update() {
    if (!hasStarted && QuestManager.instance.questStep == questStep) {
      StartCoroutine(StartQuest());
      hasStarted = true;
    }
  }

  private IEnumerator StartQuest() {
    // Face_smile
    animator.SetInteger("Face_statement", 21);
    // Waving
    animator.SetInteger("Movement", 2);

    yield return new WaitForSeconds(3f);

    DialogueManager.instance.DialogueStart(dialogueStrings);
  }

  public void PlayWakeUp() {
    // Talk_happy
    animator.SetInteger("Face_statement", 11);
    // Idle
    animator.SetInteger("Movement", 0);
  }

  public void PlayTired() {
    // Expression_happy
    animator.SetInteger("Face_statement", 1);
    // Sitting_idle
    animator.SetInteger("Movement", 1);
  }

  public void PlayEat() {
    // Talk_happy
    animator.SetInteger("Face_statement", 11);
    // Sitting_idle
    animator.SetInteger("Movement", 1);
  }

  // TODO
  public void TmpWaitAnimate() {
    if (!hasPlayed) {
      StartCoroutine(TmpWait());
      hasPlayed = true;
    }
  }

  private IEnumerator TmpWait() {
    yield return new WaitForSeconds(3f);
    DialogueManager.instance.DialogueStart(dialogueStringsAfterKitchen);
  }

  public void PlayDoing() {
    // Talk_happy
    animator.SetInteger("Face_statement", 11);
    // Sitting_idle
    animator.SetInteger("Movement", 1);
  }

  public void PlayPotato() {
    // Expression_sorrow
    animator.SetInteger("Face_statement", 3);
    // Sitting_idle
    animator.SetInteger("Movement", 1);
  }

  public void PlayBeforeMovie() {
    // Talk_sorrow
    animator.SetInteger("Face_statement", 13);
    // Sitting_idle
    animator.SetInteger("Movement", 1);
  }

  public void PlayAfterMovie() {
    // Face_smile
    animator.SetInteger("Face_statement", 21);
    // Idle
    animator.SetInteger("Movement", 0);
  }

  public void PlayASAP() {
    StartCoroutine(SeqAnimate());
  }

  private IEnumerator SeqAnimate() {
    // Face_smile
    animator.SetInteger("Face_statement", 21);
    // Waving
    animator.SetInteger("Movement", 2);

    yield return new WaitForSeconds(3f);

    // Expression_happy
    animator.SetInteger("Face_statement", 1);
    // Sitting_idle
    animator.SetInteger("Movement", 1);
  }
}

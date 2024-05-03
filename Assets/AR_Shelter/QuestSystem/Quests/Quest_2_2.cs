using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest_2_2 : Quest {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private ShakeEffect shakeEffect;
  [SerializeField] private GameObject wardDoorEffect;
  [SerializeField] private OpenDoor wardDoor;
  [SerializeField] private GameObject glasses;

  [HeaderAttribute("Parameters")]
  [SpaceAttribute(3)]
  [SerializeField] private float waitForSeconds = 300f;
  [SerializeField] private float shakeTime = 60f;
  [SerializeField] private bool isEarthquake = false;

  [HeaderAttribute("Dialogues After Earthquake")]
  [SpaceAttribute(3)]
  [SerializeField] private List<DialogueString> dialogueAfterEarthquakeStrings = new();

  public static event Action MemoryStartEvent;

  void Update() {
    if (wardDoor.isOpen) {
      wardDoorEffect.SetActive(false);
    }
  }

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  public void SetIsEarthquake(bool value) {
    isEarthquake = value;
  }

  IEnumerator QuestRoutine() {
    MemoryStartEvent?.Invoke();

    // DEBUG
    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));
    // yield return new WaitForSeconds(waitForSeconds);
    
    AudioManager.instance.StopAllAudio();
    // AudioManager.instance.FadeOut("BGM", true);
    shakeEffect.StartShaking(60f);

    yield return new WaitForSeconds(3f);
    
    StartDialogues();
    
    yield return new WaitUntil(() => isEarthquake);
    AudioManager.instance.Play("PaperBoxFallingDown");
    yield return new WaitForSeconds(0.2f);

    FadeScreen.instance.FadeOut(0.5f);
    AudioManager.instance.Play("BrokenGlass");
    glasses.SetActive(true);
    yield return new WaitForSeconds(1f);
    FadeScreen.instance.FadeIn(1f);

    DialogueManager.instance.DialogueStart(dialogueAfterEarthquakeStrings);
  }
}

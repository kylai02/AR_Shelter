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

  private float timer = 0f;

  void Update() {
    if (wardDoor.isOpen) {
      wardDoorEffect.SetActive(false);
    }

    timer += Time.deltaTime;
  }

  protected override void StartQuest() {
    StartCoroutine(QuestRoutine());
  }

  public void SetIsEarthquake(bool value) {
    isEarthquake = value;
  }

  IEnumerator QuestRoutine() {
    MemoryStartEvent?.Invoke();

    timer = 0;
    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q) || timer >= waitForSeconds);
    
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
    yield return new WaitForSeconds(1f);
    glasses.SetActive(true);
    FadeScreen.instance.FadeIn(1f);

    DialogueManager.instance.DialogueStart(dialogueAfterEarthquakeStrings);
  }
}

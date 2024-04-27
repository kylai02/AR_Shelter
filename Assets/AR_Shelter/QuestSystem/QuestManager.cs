using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour {
  public static QuestManager instance;
  public static event Action<string> QuestStartEvent;

  [SerializeField] private List<string> questQueue = new();
  [SerializeField] private float initQuestTimer = 5f;
  public string questStep = "0";
  private bool hasBegin = false;

  void Start() {
    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
    }
  }

  void Update() {
    if (!hasBegin) {
      initQuestTimer -= Time.deltaTime;
      
      if (initQuestTimer <= 0) {
        StartNextQuest();
        hasBegin = true;
      }
    }
  }

  public void SetQuestStep(string questId) {
    questStep = questId;
  }

  public void StartNextQuest() {
    try {
      string questToStart = questQueue[0];
      questQueue.RemoveAt(0);
      SetQuestStep(questToStart);
      QuestStartEvent?.Invoke(questToStart);
    } catch {
      return;
    }
  }
}

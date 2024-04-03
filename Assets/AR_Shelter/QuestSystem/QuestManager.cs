using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour {
  public static QuestManager instance;
  public string questStep;

  void Start() {
    instance = this;
    questStep = "0";
  }
}

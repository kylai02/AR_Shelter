using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class TestFunction : MonoBehaviour {
  public GameObject glasses;

  void Update() {
    if (Input.GetKeyDown(KeyCode.G)) {
      glasses.transform.DOLocalMoveY(0.4f, 4);
    }
  }
}

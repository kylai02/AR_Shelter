using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestFunction : MonoBehaviour {
  void Update() {
    if (Input.GetKeyDown(KeyCode.T)) {
      SceneManager.LoadScene(4);
    }
  }
}

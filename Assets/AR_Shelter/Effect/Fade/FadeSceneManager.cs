using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeSceneManager : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private FadeScreen fadeScreen;

  public static FadeSceneManager instance;

  void Start() {
    instance = this;
  }

  public void GoToScene(int sceneIndex) {
    StartCoroutine(GoToSceneRoutine(sceneIndex));
  }

  IEnumerator GoToSceneRoutine(int sceneIndex) {
    fadeScreen.FadeOut();
    yield return new WaitForSeconds(fadeScreen.fadeDuration);

    SceneManager.LoadScene(sceneIndex);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeScreen : MonoBehaviour {
  [HeaderAttribute("Settings")]
  [SpaceAttribute(3)]
  [SerializeField] public float fadeDuration = 2f;
  [SerializeField] private bool fadeOnStart = false;
  [SerializeField] private Color fadeColor;

  private Renderer render;

  void Start() {
    render = GetComponent<Renderer>();

    if (fadeOnStart) {
      FadeIn();
    }
  }

  public void FadeIn() {
    Fade(1, 0);
  }

  public void FadeOut() {
    Fade(0, 1);
  }

  public void Fade(float alphaIn, float alphaOut) {
    StartCoroutine(FadeRoutine(alphaIn, alphaOut));
  }

  IEnumerator FadeRoutine(float alphaIn, float alphaOut) {
    float timer = 0;
    while (timer <= fadeDuration) {
      Color newColor = fadeColor;
      newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

      render.material.SetColor("_BaseColor", newColor);
      Debug.Log("here");

      timer += Time.deltaTime;
      yield return null;
    }

    Color finalColor = fadeColor;
    finalColor.a = alphaOut;
    render.material.SetColor("_Color", finalColor);

  }
}

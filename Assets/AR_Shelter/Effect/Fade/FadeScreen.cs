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

  public static FadeScreen instance;

  void Start() {
    render = GetComponent<Renderer>();
    instance = this;

    if (fadeOnStart) {
      FadeIn();
    }
  }

  public void FadeIn() {
    Fade(1, 0, fadeDuration);
  }

  public void FadeIn(float duration) {
    Fade(1, 0, duration);
  }

  public void FadeOut() {
    Fade(0, 1, fadeDuration);
  }
  
  public void FadeOut(float duration) {
    Fade(0, 1, duration);
  }

  public void Fade(float alphaIn, float alphaOut, float duration) {
    StartCoroutine(FadeRoutine(alphaIn, alphaOut, duration));
  }

  IEnumerator FadeRoutine(float alphaIn, float alphaOut, float duration) {
    float timer = 0;
    while (timer <= duration) {
      Color newColor = fadeColor;
      newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / duration);

      render.material.SetColor("_BaseColor", newColor);

      timer += Time.deltaTime;
      yield return null;
    }

    Color finalColor = fadeColor;
    finalColor.a = alphaOut;
    render.material.SetColor("_Color", finalColor);

  }
}

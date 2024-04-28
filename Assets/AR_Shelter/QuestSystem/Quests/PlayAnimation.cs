using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAnimation : MonoBehaviour {
  [HeaderAttribute("References")]
  [SpaceAttribute(3)]
  [SerializeField] private GameObject targetEffect;

  private bool hasPlayed = false;

  void Awake() {
    Quest_2_2.MemoryStartEvent += CanPlayAnimation;
  }

  void OnDisable() {
    Quest_2_2.MemoryStartEvent -= CanPlayAnimation;
  }

  private void CanPlayAnimation() {
    targetEffect?.SetActive(true);
  }
}

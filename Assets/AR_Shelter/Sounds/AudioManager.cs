using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour {
  public static AudioManager instance;
  public Sound[] sounds;

  void Awake() {
    instance = this;

    foreach (Sound s in sounds) {
      if (!s.is3dSound) {
        s.source = gameObject.AddComponent<AudioSource>();
      }
      
      s.source.clip = s.clip;
      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
    }

    Sound bgm = Array.Find(sounds, sound => sound.name == "BGM");
    if (bgm != null) {
      bgm.source.loop = true;
    }

  }

  public void Play(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    s.source.volume = s.volume;
    s.source.Play();
  }

  public void FadeIn(string name, bool unPause) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    float targetVol = s.volume;
    s.source.volume = 0;

    if (unPause) {
      s.source.UnPause();
    } else {
      s.source.Play();
    }

    DOTween.To(() => s.source.volume, x => s.source.volume = x, targetVol, 2);
  }

  public void Stop(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    s.source.Stop();
  }

  public void FadeOut(string name, bool pause) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    DOTween.To(() => s.source.volume, x => s.source.volume = x, 0, 2).OnComplete(() => {
      if (pause) {
        s.source.Pause();
      } else {
        s.source.Stop();
      }
    });
  }

  public void BGMFadeOut() {
    FadeOut("BGM", true);
  }

  public void StopAllAudio() {
    foreach (Sound s in sounds) {
      FadeOut(s.name, false);
    }
  }
}

[System.Serializable]
public class Sound {
  public string name;
  public AudioClip clip;
  public bool is3dSound = false;

  [Range(0f, 1f)]
  public float volume;

  [Range(0.1f, 3f)]
  public float pitch = 1;

  public AudioSource source;
}

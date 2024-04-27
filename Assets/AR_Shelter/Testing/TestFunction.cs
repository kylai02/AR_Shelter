using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;


public class TestFunction : MonoBehaviour {
  void Update() {
    if (Input.GetKeyDown(KeyCode.V)) {
      SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 5, 30, 10);
      SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, 5, 30, 10);
    }
  }
}

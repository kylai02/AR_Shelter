using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;


public class Move : MonoBehaviour {
  private SteamVR_Action_Boolean forward = SteamVR_Input.GetBooleanAction("Forward");
  public SteamVR_Input_Sources curIndex;
  public int test;
  
  // Start is called before the first frame update
  void Start() {
    test = 0;
  }

  // Update is called once per frame
  void Update() {
    if (forward.GetStateDown(curIndex)) {
      Debug.Log("forward");
      test++;
    }
  }
}

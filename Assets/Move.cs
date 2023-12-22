using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;


public class Move : MonoBehaviour {
  public SteamVR_Input_Sources curIndex;
  public float speed;

  public Transform camera;
  
  public bool forwarding;
  public int ctr;
  
  private SteamVR_Action_Boolean forward = SteamVR_Input.GetBooleanAction("Forward");

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {
    forwarding = forward.GetState(curIndex);
    
    if (forwarding) {
      transform.position = new Vector3(
        transform.position.x + camera.forward.x * speed,
        transform.position.y,
        transform.position.z + camera.forward.z * speed
      );
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follow : MonoBehaviour {
  [Header("Parameter")]
  [SerializeField] private float distanceFromCamera = 0.2f;
  [SerializeField] private float verticalOffset = -0.2f;
  [SerializeField] private float smoothTime = 1f;
  [SerializeField] private float maxAngleDistance = 10f;
  [SerializeField] private ClampValue xClampValue;

  private Camera mainCamera;

  private float currentYVelocity = 1;

  void Start() {
    mainCamera = Camera.main;
  }

  void LateUpdate() {
    Move();
    RotateX();
    RotateY();
  }

  private void Move() {
    Vector3 targetPos = mainCamera.transform.position + 
      mainCamera.transform.forward * distanceFromCamera +
      mainCamera.transform.up * verticalOffset;
    transform.position = targetPos;
  }

  private void RotateX() {
    float xAngle = mainCamera.transform.eulerAngles.x;

    float start = (xClampValue.min + xClampValue.max) * 0.5f - 180;
    float floor = Mathf.FloorToInt((xAngle - start) / 360) * 360;
    xAngle = Mathf.Clamp(xAngle, xClampValue.min + floor, xClampValue.max + floor);

    transform.eulerAngles = new Vector3(
      xAngle, 
      transform.eulerAngles.y, 
      transform.eulerAngles.z
    );
  }

  private void RotateY() {
    float targetYRotation = mainCamera.transform.eulerAngles.y;
    float currentYRotation = transform.eulerAngles.y;

    float distance = Mathf.Abs(currentYRotation - targetYRotation);
    if (distance > maxAngleDistance) {
      float newAngle = Mathf.SmoothDampAngle(
        current: currentYRotation,
        target: targetYRotation,
        currentVelocity: ref currentYVelocity,
        smoothTime: Time.deltaTime * smoothTime
      );

      transform.eulerAngles = new Vector3(
        transform.rotation.eulerAngles.x,
        newAngle,
        0
      );
    }
  }
}

[System.Serializable]
public class ClampValue {
  public float min;
  public float max;
}

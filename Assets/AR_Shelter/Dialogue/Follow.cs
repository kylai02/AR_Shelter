using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follow : MonoBehaviour {
  [Header("Parameter")]
  [SerializeField] private float _distanceFromCamera = 0.3f;
  [SerializeField] private float _verticalOffset = -0.1f;
  [SerializeField] private float _smoothTime = 5f;
  [SerializeField] private float _maxAngleDistance = 10f;
  [SerializeField] private ClampValue _xClampValue;

  private Camera _mainCamera;

  private float _currentYVelocity = 1;

  void Start() {
    _mainCamera = Camera.main;
  }

  void LateUpdate() {
    Move();
    RotateX();
    RotateY();
  }

  // Position the object to the specified location
  private void Move() {
    Vector3 targetPos = _mainCamera.transform.position + 
      _mainCamera.transform.forward * _distanceFromCamera +
      _mainCamera.transform.up * _verticalOffset;

    transform.position = targetPos;
  }

  // Make the object face the camera (up and down rotation)
  private void RotateX() {
    float xAngle = _mainCamera.transform.eulerAngles.x;

    float start = (_xClampValue.min + _xClampValue.max) * 0.5f - 180;
    float floor = Mathf.FloorToInt((xAngle - start) / 360) * 360;
    xAngle = Mathf.Clamp(
      xAngle, 
      _xClampValue.min + floor, 
      _xClampValue.max + floor
    );

    transform.eulerAngles = new Vector3(
      xAngle, 
      transform.eulerAngles.y, 
      transform.eulerAngles.z
    );
  }

  // Smoothly rotate the object towards the camera (left and right rotation)
  private void RotateY() {
    float targetYRotation = _mainCamera.transform.eulerAngles.y;
    float currentYRotation = transform.eulerAngles.y;
    float distance = Mathf.Abs(currentYRotation - targetYRotation);

    // Only rotate if the angle is greater than the specified value
    if (distance > _maxAngleDistance) {
      float newAngle = Mathf.SmoothDampAngle(
        current: currentYRotation,
        target: targetYRotation,
        currentVelocity: ref _currentYVelocity,
        smoothTime: Time.deltaTime * _smoothTime
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

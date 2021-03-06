﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform target;
  public float offsetDistance;
  public float height;
  public float xSpeed = 250.0f;
  public float ySpeed = 120.0f;

  private Transform _myTransform;
  private float x;
  private float y;

  void Start()
  {
    if (target == null)
      Debug.LogWarning("We do not have a target.");

    _myTransform = transform;
    CameraSetup();
  }

  void LateUpdate()
  {

    x += Input.GetAxis("Mouse X") * xSpeed * .02f;
    y -= Input.GetAxis("Mouse Y") * ySpeed * .02f;

    // y = ClampAngle(y, yMinLimit, yMaxLimit);

    Quaternion rotation = Quaternion.Euler(y, x, 0);
    Vector3 position = rotation * new Vector3(0f, 0f, -offsetDistance) + target.position;

    // For some reason _myTransform is not accessible here
    // So we have to use the regular transform
    transform.rotation = rotation;
    transform.position = position;
  }

  public void CameraSetup()
  {
    _myTransform.position = new Vector3(
      target.position.x,
      target.position.y + height,
      target.position.z - offsetDistance
    );

    _myTransform.LookAt(target);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private Rigidbody rb;
  public Camera targetCamera;

  private void AlignToCamera()
  {
    transform.rotation = Quaternion.Euler(
      transform.eulerAngles.x,
      targetCamera.transform.eulerAngles.y,
      transform.eulerAngles.z
    );
  }

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    // AlignToCamera();
  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 input = new Vector3(moveHorizontal, 0.0f, moveVertical);

    transform.position += input * speed * Time.deltaTime;

    AlignToCamera();
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private Rigidbody _body;
  public Camera targetCamera;
  private Vector3 _inputs = Vector3.zero;

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
    _body = GetComponent<Rigidbody>();
  }

  void Update()
  {
    _inputs = Vector3.zero;
    _inputs.x = Input.GetAxis("Horizontal");
    _inputs.z = Input.GetAxis("Vertical");
    if (_inputs != Vector3.zero)
      transform.forward = _inputs;
  }

  void FixedUpdate()
  {

    // _body.MovePosition(_body.position + _inputs * speed * Time.fixedDeltaTime);
    Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

    direction = Camera.main.transform.TransformDirection(direction);
    direction.y = 0.0f;

    transform.position += Vector3.Normalize(direction);

    // AlignToCamera();
  }
}

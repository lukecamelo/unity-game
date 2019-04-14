using UnityEngine;

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
  }

  void LateUpdate()
  {

    x += Input.GetAxis("Mouse X") * xSpeed * .02f;
    y += Input.GetAxis("Mouse X") * ySpeed * .02f;

    // y = ClampAngle(y, yMinLimit, yMaxLimit);

    Quaternion rotation = Quaternion.Euler(y, x, 0);
    Vector3 position = rotation * new Vector3(0f, 0f, -offsetDistance) + target.position;

    transform.rotation = rotation;
    transform.position = position;


    // _myTransform.position = new Vector3(
    //   target.position.x,
    //   target.position.y + height,
    //   target.position.z - offsetDistance
    // );

    // _myTransform.LookAt(target);
  }
}

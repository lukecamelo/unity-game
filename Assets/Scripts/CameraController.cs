using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform target;
  public float offsetDistance;
  public float height;
  private Transform _myTransform;

  void Start()
  {
    if (target == null)
      Debug.LogWarning("We do not have a target.");
    _myTransform = transform;
  }

  void LateUpdate()
  {

    _myTransform.position = new Vector3(
      target.position.x,
      target.position.y + height,
      target.position.z - offsetDistance
    );

    _myTransform.LookAt(target);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  /// <summary>
  /// Gameobject to follow.
  /// </summary>
  public Transform Target;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void LateUpdate()
  {
    var targetPos = Target.position;
    transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
  }
}

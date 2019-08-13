using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float Speed = .3f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Move();
    OrientationToMouse();
  }

  void OrientationToMouse()
  {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
  }

  void Move()
  {
    var move = Vector3.zero;
    move.x = Input.GetAxisRaw("Horizontal");
    move.y = Input.GetAxisRaw("Vertical");

    if (move != Vector3.zero)
    {
      move.Normalize();
      transform.position += move * Speed;
    }
      
  }
}
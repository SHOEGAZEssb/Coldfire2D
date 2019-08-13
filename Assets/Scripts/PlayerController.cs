using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float Speed = .3f;
  // Start is called before the first frame update
  void Start()
  {
    Cursor.visible = true;
    var tex = Resources.Load<Texture2D>("Sprites/Crossair");
    Cursor.SetCursor(tex, new Vector2(tex.width / 2, tex.height / 2), CursorMode.Auto);
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
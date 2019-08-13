using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
  }
}

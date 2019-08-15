using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float Speed = .3f;
  public GameObject RightHand;
  public List<GameObject> _touched;

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
    Interact();
    UseObject();
    Move();
    OrientationToMouse();
  }

  private void UseObject()
  {
    if (Input.GetMouseButtonDown(0))
    {
      var item = RightHand.transform.GetComponentInChildren<Item>();
      if (item != null)
        item.Use();
    }
  }

  void Interact()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      var obj = _touched.FirstOrDefault();
      if (obj != null)
      {
        var pickup = obj.GetComponent<ItemPickup>();
        if (pickup != null)
        {
          var item = Instantiate(pickup.TheItem, RightHand.transform.position, RightHand.transform.rotation);
          item.transform.parent = RightHand.transform;
          Destroy(obj);
        }
      }
    }
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

  void OrientationToMouse()
  {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
  }

  void OnTriggerLeave2D(Collider2D coll)
  {
    _touched.Remove(coll.gameObject);
  }

  void OnTriggerEnter2D(Collider2D coll)
  {
    _touched.Add(coll.gameObject);
  }
}
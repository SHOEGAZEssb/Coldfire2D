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
          GameObject item;
          if (RightHand.GetComponentInChildren<Item>() == null)
          {
            item = Instantiate(pickup.TheItem, RightHand.transform.position, RightHand.transform.rotation);
            item.transform.parent = RightHand.transform;
          }
          else
            item = pickup.TheItem;

          var inventory = GetComponent<Inventory>();
          if (inventory != null)
            inventory.AddItem(item.GetComponent<Item>());

          _touched.Remove(obj);
          Destroy(obj);
        }
      }
    }
    else if (Input.GetKeyDown(KeyCode.Q))
    {
      var item = RightHand.GetComponentInChildren<Item>();
      if (item != null)
      {
        Instantiate(item.PickupItem, item.transform.position, item.transform.rotation);
        Destroy(item.gameObject);

        var inventory = GetComponent<Inventory>();
        if (inventory != null)
          inventory.RemoveItem(item);
      }
    }
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

  void OnTriggerExit2D(Collider2D coll)
  {
    _touched.Remove(coll.gameObject);
  }

  void OnTriggerEnter2D(Collider2D coll)
  {
    _touched.Add(coll.gameObject);
  }
}
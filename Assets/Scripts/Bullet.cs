﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 2f;
  public Rigidbody2D rb;
  public float Lifetime = 200f;
  public int dmg;

  // Start is called before the first frame update
  void Start()
  {
    rb.velocity = transform.up * speed; // up instead of forward, because this is 2D
    Destroy(gameObject, Lifetime);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("Collision with " + collision.name + " Dmg: " + dmg);
    Destroy(gameObject);
  }
}
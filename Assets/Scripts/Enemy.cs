using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int hp;


  public void TakeDamage(int dmg)
  {
    hp -= dmg;
    Debug.Log("HIT! HP left: " + hp);
    if (hp <= 0)
      Die();
  }

  void Die()
  {
    Destroy(gameObject);
  }


}

using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{

  public Transform aoePos;
  public float aoeRange;
  public List<GameObject> enemiesInRange;
  public int dmg;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public override void Use()
  {
    var objetcs = Physics2D.OverlapCircleAll(aoePos.position, aoeRange);
    foreach (var obj in objetcs)
    {
      if (obj.CompareTag("enemy"))
      {
        Debug.Log("Damage to: " + obj.name);
        obj.GetComponent<Enemy>().TakeDamage(dmg);
      }
      
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(aoePos.position, aoeRange);
  }
}

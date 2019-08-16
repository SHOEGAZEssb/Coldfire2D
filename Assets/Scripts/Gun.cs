using UnityEngine;

public class Gun : Item
{
  public GameObject bulletPrefab;
  public Transform bulletSpawn;

  public override void Use()
  {
    Debug.Log("SHOOT");
    Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}

using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
  public float Lifetime = 2f;

  // Start is called before the first frame update
  void Start()
  {
    Destroy(gameObject, Lifetime);
  }
}
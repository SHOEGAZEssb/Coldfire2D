using UnityEngine;

public abstract class Item : MonoBehaviour
{
  public GameObject ItemPrefab;
  public GameObject PickupItem;

  public abstract void Use();
}
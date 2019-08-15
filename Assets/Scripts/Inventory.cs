using UnityEngine;

public class Inventory : MonoBehaviour
{
  public Item[] Items = new Item[20];

  public void AddItem(Item item)
  {
    for (int i = 0; i < Items.Length; i++)
    {
      if (Items[i] == null)
      {
        Items[i] = item;
        return;
      }
    }
  }

  public void RemoveItem(Item item)
  {
    for (int i = 0; i < Items.Length; i++)
    {
      if (Items[i] == item)
      {
        Items[i] = null;
        return;
      }
    }
  }
}
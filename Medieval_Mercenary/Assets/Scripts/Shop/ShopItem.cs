using UnityEngine;

[System.Serializable]
public class ShopItem : MonoBehaviour
{
    public float price;
    public bool unlocked = false;

    public ShopItem(float cost)
    {
        price = cost;
    }

    public void UnlockItem()
    {
        unlocked = true;
    }

    public void LockItem()
    {
        unlocked = false;
    }

    public bool GetItemState()
    {
        return unlocked;
    }
}

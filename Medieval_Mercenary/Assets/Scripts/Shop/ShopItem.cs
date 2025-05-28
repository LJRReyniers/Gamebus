using UnityEngine;

[System.Serializable]
public class ShopItem : MonoBehaviour
{
    public float price;
    public bool unlocked;
    public float gemPrice;

    public ShopItem(float cost, float gemCost)
    {
        price = cost;
        gemPrice = gemCost;
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

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBuilder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinAmount;
    [SerializeField] private TextMeshProUGUI _gemAmount;
    [SerializeField] private List<GameObject> shopItems = new List<GameObject>();

    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _popupScreen;

    private GameObject _selectedShopItem;

    private void Start()
    {
        SetCoinAmount();
        SetGemAmount();
        SetShopItemPrice();
        SetShopItemState();
    }

    public void EquipWeapon(string weapon)
    {
        WeaponManager.Instance.SelectWeapon(weapon);
    }

    public void Dashboard()
    {
        SceneController.Instance.loadScene(1);
    }

    private void SetCoinAmount()
    {
        _coinAmount.text = $"{Wallet.Instance.GetCoinCount()}";
    }

    private void SetGemAmount()
    {
        _gemAmount.text = $"{Wallet.Instance.GetGemCount()}";
    }

    private void SetShopItemPrice()
    {
        foreach (var item in shopItems)
        {
            GlobalManager.Instance.SetItemPrice(item.name);
        }
    }

    public void SetShopItemState()
    {
        foreach (var item in shopItems)
        {
            if (!GlobalManager.Instance.GetCurrentItemState(item.name))
            {
                item.GetComponent<Image>().color = Color.black;
            }
            else
            {
                item.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void CheckIfWeaponCanBeEquipped(GameObject weapon)
    {
        if (weapon.GetComponent<Image>().color == Color.white)
        {
            EquipWeapon(weapon.name);
        }
        else
        {
            PopupWindow(weapon);
        }
    }

    public void BuyItem()
    {
        GlobalManager.Instance.BuyShopItem(_selectedShopItem.name);
        _popupScreen.SetActive(false);
        SetCoinAmount();
    }

    private void PopupWindow(GameObject weapon)
    {
        _selectedShopItem = weapon;
        _popupScreen.SetActive(true);
        _popupScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"Do you want to buy {weapon.name} for $ {GlobalManager.Instance.GetItemPrice(weapon.name)}?";
        if (Wallet.Instance.GetCoinCount() < GlobalManager.Instance.GetItemPrice(weapon.name))
        {
            _popupScreen.GetComponentInChildren<Button>().interactable = false;
        }
    }
}

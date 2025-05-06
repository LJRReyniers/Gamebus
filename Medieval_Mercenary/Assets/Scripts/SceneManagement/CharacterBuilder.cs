using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBuilder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinAmount;
    [SerializeField] private List<GameObject> shopItems = new List<GameObject>();

    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _popupScreen;

    private GameObject _selectedShopItem;

    private void Start()
    {
        SetCoinAmount();
        SetShopItemPrice();
        SetShopItemState();
    }

    public void EquipWeapon(string weapon)
    {
        WeaponManager.Instance.SelectWeapon(weapon);
    }

    public void Dashboard()
    {
        SceneController.Instance.loadScene(0);
    }

    private void SetCoinAmount()
    {
        _coinAmount.text = $"{Wallet.Instance.GetCoinCount()}";
    }

    private void SetShopItemPrice()
    {
        foreach (var item in shopItems)
        {
            GlobalManager.Instance.SetItemPrice(item);
        }
    }

    public void SetShopItemState()
    {
        foreach (var item in shopItems)
        {
            Debug.Log($"{item}: {GlobalManager.Instance.GetCurrentItemState(item)}");
            if (!GlobalManager.Instance.GetCurrentItemState(item))
            {
                //item.GetComponent<Button>().interactable = false;
                item.GetComponent<Image>().color = Color.black;
            }
            else
            {
                //item.GetComponent<Button>().interactable = true;
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
        GlobalManager.Instance.BuyShopItem(_selectedShopItem);
        _popupScreen.SetActive(false);
        SetCoinAmount();
    }

    private void PopupWindow(GameObject weapon)
    {
        _selectedShopItem = weapon;
        _popupScreen.SetActive(true);
        _popupScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"Do you want to buy {weapon.name} for $ {GlobalManager.Instance.GetItemPrice(weapon)}?";
        if (Wallet.Instance.GetCoinCount() < GlobalManager.Instance.GetItemPrice(weapon))
        {
            _popupScreen.GetComponentInChildren<Button>().interactable = false;
        }
    }
}

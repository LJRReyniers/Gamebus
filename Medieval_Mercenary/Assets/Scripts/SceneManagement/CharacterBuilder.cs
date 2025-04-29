using TMPro;
using UnityEngine;

public class CharacterBuilder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinAmount;

    private void Start()
    {
        SetCoinAmount();
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
}

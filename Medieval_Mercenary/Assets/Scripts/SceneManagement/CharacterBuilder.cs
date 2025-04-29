using TMPro;
using UnityEngine;

public class CharacterBuilder : MonoBehaviour
{
    //[SerializeField] private SceneController _sceneController;
    [SerializeField] private TextMeshProUGUI _coinAmount;

    private void Start()
    {
        SetCoinAmount();
    }

    public void EquipWeapon(string weapon)
    {
        if (WeaponManager.Instance.SelectWeapon(weapon))
        {
            // Proceed with scene transition
            /*var handler = GetComponent<SceneController>();
            handler.loadScene(0);*/
        }
    }

    public void Dashboard()
    {
        SceneController.Instance.loadScene(0);
        //_sceneController.loadScene(0);
        /*var handler = FindAnyObjectByType<SceneController>();
        handler.loadScene(0);*/
    }

    private void SetCoinAmount()
    {
        _coinAmount.text = $"{Wallet.Instance.GetCoinCount()}";
    }
}

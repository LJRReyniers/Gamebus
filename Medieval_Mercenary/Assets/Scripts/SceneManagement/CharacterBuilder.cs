using UnityEngine;

public class CharacterBuilder : MonoBehaviour
{
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
    }
}

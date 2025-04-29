using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour
{
        public static WeaponManager Instance { get; private set; }
        public string selectedWeapon { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("WeaponManager initialized");
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                Debug.LogWarning("Duplicate WeaponManager destroyed");
            }
        }

        public bool SelectWeapon(string weapon)
        {
            if (weapon == null)
            {
                Debug.LogError("Attempted to select null weapon");
                return false;
            }

            selectedWeapon = weapon;
            Debug.Log($"Weapon selected: {weapon}");
            return true;
        }

        public string GetSelectedWeapon()
        {
            if (selectedWeapon == null)
            {
                Debug.LogWarning("No weapon selected");
                return null;
            }

            return selectedWeapon;
        }
}

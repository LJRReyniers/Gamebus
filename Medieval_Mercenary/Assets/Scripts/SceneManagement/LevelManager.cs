using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> _availableWeapons;

    private void Awake()
    {
        var weapon = WeaponManager.Instance.GetSelectedWeapon();
        if (weapon != null)
        {
            // Initialize level with selected weapon
            InitializeLevel(weapon);
        }
        else
        {
            weapon = "Empty";
            InitializeLevel(weapon);
        }
    }

    protected virtual void InitializeLevel(string weapon)
    {
        // Override in derived classes for specific initialization
        foreach (var w in _availableWeapons)
        {
            if (w.name == weapon)
            {
                //Debug.Log(GameObject.Find(weapon));
                GameObject.Find(w.name).SetActive(true);
                w.enabled = true;
            }
            else
            {
                //Debug.Log(GameObject.Find(weapon));
                GameObject.Find(w.name).SetActive(false);
                w.enabled = false;
            }
        }
    }
}

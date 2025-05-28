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
        foreach (var w in _availableWeapons)
        {
            if (w.name == weapon)
            {
                GameObject.Find(w.name).SetActive(true);
                w.enabled = true;
            }
            else
            {
                GameObject.Find(w.name).SetActive(false);
                w.enabled = false;
            }
        }
    }

    public void Win()
    {
        Wallet.Instance.AddCoins(GlobalManager.Instance.GetCurrentReward(SceneController.Instance.GetSceneName()));
        //GlobalManager.Instance.AddAttempts(SceneController.Instance.GetSceneName());
        GlobalManager.Instance.LevelStateChange(SceneController.Instance.GetSceneName());
        
        SceneController.Instance.loadScene(1);
    }

    public void Lose()
    {
        GlobalManager.Instance.LessenReward(SceneController.Instance.GetSceneName());

        SceneController.Instance.loadScene(1);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float _sceneFadeDuration;
    private SceneFade _sceneFade;

    private void Awake()
    {
        _sceneFade = GetComponentInChildren<SceneFade>();
    }

    private IEnumerator Start()
    {
        yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration);
    }

    public void loadScene(int index)
    {
        /*if (!ValidateWeaponState())
        {
            Debug.LogError("Cannot load scene: Weapon state invalid");
            return;
        }*/

        StartCoroutine(LoadSceneByIndex(index));
    }

    /*private bool ValidateWeaponState()
    {
        if (WeaponManager.Instance == null)
        {
            Debug.LogError("WeaponManager instance missing");
            return false;
        }

        var weapon = WeaponManager.Instance.GetSelectedWeapon();
        return weapon != null;
    }*/

    private IEnumerator LoadSceneByIndex(int index)
    {
        yield return _sceneFade.FadeOutCoroutine(_sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(index);
    }
}

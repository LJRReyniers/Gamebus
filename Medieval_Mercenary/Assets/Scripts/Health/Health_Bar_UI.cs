using UnityEngine;

public class Health_Bar_UI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _healthBarForegroundImage;

    public void UpdateHealthBar(Health_Controller health_Controller)
    {
        _healthBarForegroundImage.fillAmount = health_Controller.RemainingHealthPercentage;
    }
}

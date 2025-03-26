using UnityEngine;

public class Player_Damaged_Invincibility : MonoBehaviour
{
    [SerializeField] private float _invincibilityDuration;
    [SerializeField] private Color _flashColour;
    [SerializeField] private int _numberOfFlashes;

    private Invincibility_Controller _invincibilityController;

    private void Awake()
    {
        _invincibilityController = GetComponent<Invincibility_Controller>();
    }

    public void StartInvincibility()
    {
        _invincibilityController.StartInvincibility(_invincibilityDuration, _flashColour, _numberOfFlashes);
    }
}

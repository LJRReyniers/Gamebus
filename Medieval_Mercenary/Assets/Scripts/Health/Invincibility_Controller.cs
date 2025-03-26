using System.Collections;
using UnityEngine;

public class Invincibility_Controller : MonoBehaviour
{
    private Health_Controller _healthController;
    private Sprite_Flash _spriteFlash;

    private void Awake()
    {
        _healthController = GetComponent<Health_Controller>();
        _spriteFlash = GetComponent<Sprite_Flash>();
    }

    public void StartInvincibility(float invincibilityDuration, Color flashColour, int numberOfFlashes)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColour, numberOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColour, int numberOfFlashes)
    {
        _healthController.IsInvincible = true;
        yield return _spriteFlash.FlashCoroutine(invincibilityDuration, flashColour, numberOfFlashes);
        _healthController.IsInvincible = false;
    }
}

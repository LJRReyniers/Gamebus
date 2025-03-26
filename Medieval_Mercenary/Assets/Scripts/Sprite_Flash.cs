using System.Collections;
using UnityEngine;

public class Sprite_Flash : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColour, int numberOfFlashes)
    {
        Color startColour = _spriteRenderer.color;
        float elapsedFlashTime = 0;
        float elapsedFlashPercentage = 0;

        while (elapsedFlashTime < flashDuration)
        {
            elapsedFlashTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedFlashTime / flashDuration;

            if (elapsedFlashPercentage > 1)
            {
                elapsedFlashPercentage = 1;
            }

            float pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2 * numberOfFlashes, 1);

            _spriteRenderer.color = Color.Lerp(startColour, flashColour, pingPongPercentage);

            yield return null;
        }
    }
}

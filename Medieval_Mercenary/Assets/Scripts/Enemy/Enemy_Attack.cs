using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [SerializeField] private float _damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var healthController = collision.gameObject.GetComponent<Health_Controller>();

            healthController.TakeDamage(_damageAmount);
        }
    }
}

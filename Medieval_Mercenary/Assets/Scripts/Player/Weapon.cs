using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    //make weapon types
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var healthController = collision.gameObject.GetComponent<Health_Controller>();

            healthController.TakeDamage(_damageAmount);
        }
    }
}

using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _damageAmount;
    private string _weaponType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var healthController = collision.gameObject.GetComponent<Health_Controller>();

            healthController.TakeDamage(_damageAmount);
        }
    }
}

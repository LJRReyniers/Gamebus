using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public float _damageAmount;
    public string _weaponType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var healthController = collision.gameObject.GetComponent<Health_Controller>();

            healthController.TakeDamage(_damageAmount);
        }
    }
}

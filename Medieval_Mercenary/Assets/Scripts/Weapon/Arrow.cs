using UnityEngine;

public class Arrow : Weapon
{
    private void Start()
    {
        this._damageAmount = 20f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var healthController = collision.gameObject.GetComponent<Health_Controller>();

            healthController.TakeDamage(_damageAmount);
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}

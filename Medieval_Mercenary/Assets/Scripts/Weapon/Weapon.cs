using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public float _damageAmount;
    //[SerializeField] public Animator _animation;
    public string _weaponType;
    //private UnityEvent player_Event;

    /*private void Start()
    {
        player_Event = GetComponentInParent<Player_Attack>().playerAttack_Event;
        player_Event.AddListener(Attack);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var healthController = collision.gameObject.GetComponent<Health_Controller>();

            healthController.TakeDamage(_damageAmount);
        }
    }

    /*public void Attack()
    {

    }*/
}

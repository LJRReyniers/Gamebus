using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Sword : Weapon
{
    [SerializeField] private Animator _animation;
    private UnityEvent player_Event;

    void Start()
    {
        this._damageAmount = 20f;
        this._weaponType = "Slash";
        player_Event = GetComponentInParent<Player_Attack>().playerAttack_Event;
        player_Event.AddListener(Attack);
    }

    private void Attack() 
    {
        StartCoroutine(AttackCollision());
    }

    IEnumerator AttackCollision()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;

        yield return new WaitForSeconds(1);

        this.GetComponent<BoxCollider2D>().enabled = false;

        yield return 0;
    }
}

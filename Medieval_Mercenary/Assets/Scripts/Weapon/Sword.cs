using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Sword : Weapon
{
    [SerializeField] private Animator _animation;
    //[SerializeField] private Animator _playerAnimation;
    //private float _damageAmount = 20f;
    //private string _attackType = "Slash";
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
        //this.GetComponent<BoxCollider2D>().enabled = true;
        //_animation.Play(_attackType);

        StartCoroutine(AttackCollision());

        /*this.GetComponent<BoxCollider2D>().enabled = true;
        _animation.SetBool("ColliderEnabled", this.GetComponent<BoxCollider2D>().enabled);*/

        //_animation.Play(_weaponType);

        /*this.GetComponent<BoxCollider2D>().enabled = false;
        _animation.SetBool("ColliderEnabled", this.GetComponent<BoxCollider2D>().enabled);*/
    }

    IEnumerator AttackCollision()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        //_animation.SetBool("ColliderEnabled", this.GetComponent<BoxCollider2D>().enabled);

        //_playerAnimation.Play("Empty");
        //_animation.Play(_attackType);
        yield return new WaitForSeconds(1);

        this.GetComponent<BoxCollider2D>().enabled = false;
        //_animation.SetBool("ColliderEnabled", this.GetComponent<BoxCollider2D>().enabled);

        yield return 0;
    }
}

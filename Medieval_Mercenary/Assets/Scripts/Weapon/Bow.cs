using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bow : Weapon
{
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private float _arrowSpeed;
    [SerializeField] private Transform _arrowOffset;
    [SerializeField] private Animator _animation;

    private UnityEvent player_Event;

    void Start()
    {
        player_Event = GetComponentInParent<Player_Attack>().playerAttack_Event;
        player_Event.AddListener(Attack);
    }

    private void FireArrow()
    {
        GameObject arrow = Instantiate(_arrowPrefab, _arrowOffset.position, transform.rotation);
        Rigidbody2D rigidbody = arrow.GetComponent<Rigidbody2D>();

        rigidbody.linearVelocity = _arrowSpeed * transform.up;
    }

    private void Attack()
    {
        StartCoroutine(AttackCollision());
    }

    IEnumerator AttackCollision()
    {
        yield return new WaitForSeconds(0.5f);
        FireArrow();

        yield return 0;
    }
}

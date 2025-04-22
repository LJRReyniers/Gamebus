using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    private InputAction _attackAction;
    private string _attackType;

    private bool _attackButtonPressed = false;
    public UnityEvent playerAttack_Event;

    private bool _canAttack = true;

    void Start()
    {
        _attackType = GetComponentInChildren<Weapon>()._weaponType;
        _attackAction = InputSystem.actions.FindAction("Attack");
        if (playerAttack_Event == null)
        {
            playerAttack_Event = new UnityEvent();
        }
    }

    void Update()
    {
        if (_attackButtonPressed && playerAttack_Event != null && _canAttack)
        {
            _animation.Play(_attackType);

            playerAttack_Event.Invoke();
            _canAttack = false;
        }

        OnAttack(_attackAction);
    }

    public void OnAttack(InputAction inputAction)
    {
        _attackButtonPressed = inputAction.IsPressed();
    }

    public void CanAttack()
    {
        _canAttack = true;
    }
}

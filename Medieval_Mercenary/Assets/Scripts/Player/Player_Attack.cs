using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    private InputAction _attackAction;
    private string _attackType;

    //[SerializeField] private Weapon _weapon;
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
            //_weapon.GetComponent<BoxCollider2D>().enabled = true;
            playerAttack_Event.Invoke();
            _canAttack = false;
        }
        else
        {
            //_weapon.GetComponent<BoxCollider2D>().enabled = false;
        }

        OnAttack(_attackAction);
    }

    public void OnAttack(InputAction inputAction)
    {
        _attackButtonPressed = inputAction.IsPressed();
        //_animation.SetBool("Attack_Button_Pressed", inputAction.IsPressed());
    }

    public void CanAttack()
    {
        _canAttack = true;
    }
}

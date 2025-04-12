using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    private InputAction _attackAction;

    [SerializeField] private Weapon _weapon;
    private bool _attackButtonPressed = false;

    void Start()
    {
        _attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        if (_attackButtonPressed)
        {
            _animation.Play(_weapon.name);
            _weapon.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            _weapon.GetComponent<BoxCollider2D>().enabled = false;
        }

        OnAttack(_attackAction);
    }

    public void OnAttack(InputAction inputAction)
    {
        _attackButtonPressed = inputAction.IsPressed();
        //_animation.SetBool("Attack_Button_Pressed", inputAction.IsPressed());
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Animator _animation;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private InputAction _attackAction;

    private bool _attackButtonPressed = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _attackAction = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        if (_attackButtonPressed)
        {
            _animation.Play("Slash");
        }

        OnAttack(_attackAction);
    }

    private void FixedUpdate()
    {
        SetPlayerVelodity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelodity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        _rigidbody.linearVelocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void OnAttack(InputAction inputAction)
    {
        _attackButtonPressed = inputAction.IsPressed();
        _animation.SetBool("Attack_Button_Pressed", inputAction.IsPressed());
    }
}

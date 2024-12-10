using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private float _rotationSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlaterVelocity();
        RotateDirectionOfInput();
    }

    private void SetPlaterVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);
        _rigidbody2D.linearVelocity = _smoothedMovementInput * _speed;
    }

    private void RotateDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            
            _rigidbody2D.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}

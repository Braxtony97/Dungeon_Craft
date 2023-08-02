using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _moveInput;
    private float _speedMove = 5f;

    private void Awake()
    {
        _joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    public void Move()
    {
        _moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        _rigidbody.MovePosition(_rigidbody.position + _moveInput.normalized * _speedMove * Time.deltaTime);

        if (_moveInput.x > 0) _spriteRenderer.flipX = true;
        else if (_moveInput.x < 0) _spriteRenderer.flipX = false;
    }
}

using UnityEngine;
using System;
using System.Collections;

public class MoveBehaviour : MonoBehaviour
{
    public bool DirectionLook;

    [SerializeField] private Rigidbody2D _rigidbodyPlayer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Joystick _joystick;
    private Vector2 _moveInput;
    private float _speedMove = 5f;

    private void Awake()
    {
        _joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    } 

    public void MoveJoystick()
    {
        _joystick.gameObject.SetActive(true);
        _moveInput = new Vector2 (_joystick.Horizontal, _joystick.Vertical);
        _rigidbodyPlayer.MovePosition (_rigidbodyPlayer.position + _moveInput.normalized * _speedMove * Time.deltaTime);

        if (_moveInput.x > 0) DirectionLook = _spriteRenderer.flipX = true;
        else if (_moveInput.x < 0) DirectionLook = _spriteRenderer.flipX = false;

    }

    public void MovePC()
    {
        _joystick.gameObject.SetActive(false);
        _moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbodyPlayer.MovePosition(_rigidbodyPlayer.position + _moveInput.normalized * _speedMove * Time.deltaTime);

        if (_moveInput.x > 0) DirectionLook = _spriteRenderer.flipX = true;
        else if (_moveInput.x < 0) DirectionLook = _spriteRenderer.flipX = false;
    }
}

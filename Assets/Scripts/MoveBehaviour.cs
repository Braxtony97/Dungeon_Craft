using UnityEngine;
using System;
using System.Collections;

public class MoveBehaviour : MonoBehaviour
{
    public bool DirectionLook;
    public Joystick Joystick;

    [SerializeField] private Rigidbody2D _rigidbodyPlayer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 _moveInput;
    private float _speedMove = 5f;

    private void Awake()
    {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    public void MoveJoystick()
    {
        Joystick.gameObject.SetActive(true);
        _moveInput = new Vector2 (Joystick.Horizontal, Joystick.Vertical);
        _rigidbodyPlayer.MovePosition (_rigidbodyPlayer.position + _moveInput.normalized * _speedMove * Time.deltaTime);

        if (_moveInput.x > 0) DirectionLook = _spriteRenderer.flipX = true;
        else if (_moveInput.x < 0) DirectionLook = _spriteRenderer.flipX = false;

    }

    public void MovePC()
    {
        Joystick.gameObject.SetActive(false);
        _moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbodyPlayer.MovePosition(_rigidbodyPlayer.position + _moveInput.normalized * _speedMove * Time.deltaTime);

        if (_moveInput.x > 0) DirectionLook = _spriteRenderer.flipX = true;
        else if (_moveInput.x < 0) DirectionLook = _spriteRenderer.flipX = false;
    }
}

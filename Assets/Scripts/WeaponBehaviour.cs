using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private Joystick _joystick;

    private void Awake()
    {
        _joystick = GameObject.FindGameObjectWithTag("JoystickShoot").GetComponent<FixedJoystick>();
    }


    public void FollowingPC ()
    {
        _joystick.gameObject.SetActive(false);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, -(rotationZ + _offset));
    }

    public void FollowingAndroid()
    {
        _joystick.gameObject.SetActive(true);
        float rotationZ = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, -(rotationZ + _offset));
    }

    public bool TouchJoystick()
    {
        if (_joystick.Horizontal >= 0.6f || _joystick.Vertical >= 0.6f) return true;
        else if (_joystick.Horizontal <= -0.6f || _joystick.Vertical <= -0.6f) return true;
        return false;
    }
}

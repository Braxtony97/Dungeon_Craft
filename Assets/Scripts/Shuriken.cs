using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private float _speed = 5;
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}

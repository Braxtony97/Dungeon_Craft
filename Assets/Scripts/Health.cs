using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health stats")]

    [SerializeField, Range(0, 100)] private int _maxHealth = 100;
    [SerializeField] private HealthBar _healthBar;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-10);
            Debug.Log(_currentHealth);
        }
    }

    private void ChangeHealth (int value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0)
        {
            Death();
        }
        else 
        {
            float _currentHealthBarAsPercantage = (float) _currentHealth / _maxHealth;
            _healthBar.OnHealthChanged(_currentHealthBarAsPercantage);
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}

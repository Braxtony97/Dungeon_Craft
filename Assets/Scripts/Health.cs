using Photon.Pun;
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
    [SerializeField] private PhotonView _photonView;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    [PunRPC]
    public void ChangeHealth (int value)
    {
        _currentHealth += value;
        Debug.Log(_currentHealth);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;

    public void OnHealthChanged (float valueAsPercantage)
    {
        _healthBarFilling.fillAmount = valueAsPercantage;
    }
}

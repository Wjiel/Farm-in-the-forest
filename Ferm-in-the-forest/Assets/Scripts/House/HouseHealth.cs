using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HouseHealth : BarVisible
{
    [SerializeField] private CanvasGroup View;
    [SerializeField] private Image HealthField;
    [SerializeField] private float MaxHealth = 100;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void GetDamage(int damage)
    {
        setVisible(true, View);

        _currentHealth -= damage;

        HealthField.fillAmount = _currentHealth / MaxHealth;
    }
}

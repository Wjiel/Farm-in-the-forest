using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HouseEnerge : BarVisible, Interactable
{
    [SerializeField] ParticleSystem Effect;
    [SerializeField] private Light lightEnergy;
    [SerializeField] private Image EnergyField;
    [SerializeField] private CanvasGroup View;
    [SerializeField] private TextMeshProUGUI Display;
    [SerializeField] private Gradient gradient;
    [SerializeField] private float MaxEnergy = 20;
    /// <summary>
    /// Лимит энергии, при котором энергия взрывается 
    /// </summary>
    [SerializeField] private float LimitEnergy = 25;

    private float _currentEnergy;
    public void ToInteract()
    {
        AddEnergy(energy: 1);
    }
    private void AddEnergy(int energy)
    {
        setVisible(true, View);

        _currentEnergy += energy;

        Limit();

        EnergyField.color = gradient.Evaluate(_currentEnergy / LimitEnergy);

        EnergyField.DOFillAmount(_currentEnergy / MaxEnergy, .4f);
        Display.text = $"{_currentEnergy} / {MaxEnergy}";
    }
    private void Limit()
    {
        lightEnergy.intensity = _currentEnergy;

        if (_currentEnergy > LimitEnergy)
        {
            _currentEnergy = 0;
            MaxEnergy--;
            LimitEnergy--;
            AddEnergy(0);

            Effect.Play();
            transform.DOShakePosition(.5f, 2, 25);
        }
    }

}
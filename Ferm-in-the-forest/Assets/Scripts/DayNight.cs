using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] private Light SunLight;

    [Header("Day")]
    [SerializeField] private float TimeDay = 360;
    [SerializeField] private float intensityDay = 2;

    [Header("Night")]
    [SerializeField] private float TimeNight = 120;
    [SerializeField] private float intensityNight = 1;


    [SerializeField] private Color dayColor = Color.white;
    [SerializeField] private Color nightColor = Color.blue;

    public static Action startNightAction;
    public static Action startDayAction;
    private void Start()
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            StartDay();
            yield return new WaitForSeconds(TimeDay);
            StartNight();
            yield return new WaitForSeconds(TimeNight);
        }
    }
    private void StartNight()
    {
        SunLight.DOIntensity(intensityNight, 10);
        SunLight.DOColor(nightColor, 10f);

        startNightAction?.Invoke();
    }
    private void StartDay()
    {
        SunLight.DOIntensity(intensityDay, 10);
        SunLight.DOColor(dayColor, 10f);

        startDayAction?.Invoke();
    }
}

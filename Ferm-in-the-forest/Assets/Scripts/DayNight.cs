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

    public static Action startNightAction;
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

        startNightAction?.Invoke();
    }
    private void StartDay()
    {
        SunLight.DOIntensity(intensityDay, 10);
    }
}

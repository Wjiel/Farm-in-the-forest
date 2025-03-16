using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс для отображения ошибок в UI.
/// </summary>
public class DisplayErrorBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;

    [SerializeField] private string errorMessage = "Default Error";

    // Время, через которое сообщение исчезнет
    [SerializeField] private float resetTime = 3f;

    private bool _isDisplaying = false;

    private float _currentTime;

    private Coroutine _resetCoroutine;

    /// <summary>
    /// Отображает сообщение об ошибке.
    /// </summary>
    public void DisplayError()
    {
        if (_isDisplaying)
        {
            // Если сообщение уже отображается, просто обновляем таймер
            ResetTimer();
            return;
        }

        _isDisplaying = true;

        displayText.text = errorMessage;

        if (_resetCoroutine == null)
        {
            _currentTime = resetTime;
            _resetCoroutine = StartCoroutine(ResetVisibility());
        }
        else
        {
            ResetTimer();
        }
    }

    /// <summary>
    /// Сбрасывает отображение ошибки.
    /// </summary>
    private void ResetDisplay()
    {
        displayText.text = string.Empty; 
        _isDisplaying = false;
        _resetCoroutine = null; 
    }

    /// <summary>
    /// Корутина для постепенного сброса видимости.
    /// </summary>
    private IEnumerator ResetVisibility()
    {
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            yield return null; 
        }

        ResetDisplay();
    }
    private void ResetTimer()
    {
        _currentTime = resetTime;
    }
}
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// ����� ��� ����������� ������ � UI.
/// </summary>
public class DisplayErrorBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;

    [SerializeField] private string errorMessage = "Default Error";

    // �����, ����� ������� ��������� ��������
    [SerializeField] private float resetTime = 3f;

    private bool _isDisplaying = false;

    private float _currentTime;

    private Coroutine _resetCoroutine;

    /// <summary>
    /// ���������� ��������� �� ������.
    /// </summary>
    public void DisplayError()
    {
        if (_isDisplaying)
        {
            // ���� ��������� ��� ������������, ������ ��������� ������
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
    /// ���������� ����������� ������.
    /// </summary>
    private void ResetDisplay()
    {
        displayText.text = string.Empty; 
        _isDisplaying = false;
        _resetCoroutine = null; 
    }

    /// <summary>
    /// �������� ��� ������������ ������ ���������.
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
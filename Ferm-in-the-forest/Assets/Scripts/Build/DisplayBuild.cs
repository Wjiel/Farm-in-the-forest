using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayErrorBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Display;
    [SerializeField] private string error;
    [SerializeField] private float TimeToReset;
    private bool _isDisplay = false;
    private float _currentTime;
    private Coroutine coroutine;
    public void DisplayError()
    {
        if (_isDisplay)
            return;

        _isDisplay = true;

        Display.text = error;

        if (coroutine == null)
        {
            _currentTime = TimeToReset;
            coroutine = StartCoroutine(resetVisible());
        }
        else
            _currentTime = TimeToReset;
    }

    private void _resetDisplay()
    {
        Display.text = null;

        _isDisplay = false;
    }

    private IEnumerator resetVisible()
    {
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }

        _resetDisplay();
        coroutine = null;
    }
}
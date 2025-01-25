using TMPro;
using UnityEngine;

public class DisplayErrorBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Display;
    [SerializeField] private string error;
    [SerializeField] private float TimeToReset;
    private bool _isDisplay = false;
    public void DisplayError()
    {
        if (_isDisplay)
            return;
            
        _isDisplay = true;

        Display.text = error;


        Invoke(nameof(_resetDisplay), TimeToReset);
    }

    private void _resetDisplay()
    {
        Display.text = null;

        _isDisplay = false;
    }
}
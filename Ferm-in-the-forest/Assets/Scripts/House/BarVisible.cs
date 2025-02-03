using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BarVisible : MonoBehaviour
{
    [SerializeField] private float timeReset;

    private bool _isVisible;
    private float _currentTime;
    private Coroutine coroutine;

    private IEnumerator resetVisible(CanvasGroup view)
    {
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }

        setVisible(false, view);
        coroutine = null;
    }

    protected void setVisible(bool value, CanvasGroup view)
    {
        _isVisible = value;


        view.DOFade(_isVisible ? 1 : 0, .4f);

        if (_isVisible)
        {
            DOTween.Sequence()
             .Append(transform.DOScale(1.2f, 0.1f))
             .Append(transform.DOScale(1f, 0.3f));


            if (coroutine == null)
            {
                _currentTime = timeReset;
                coroutine = StartCoroutine(resetVisible(view));
            }
            else
                _currentTime = timeReset;

        }

    }
}
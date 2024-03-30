using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Counter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _counterText;
    [SerializeField] private float _updateInterval = 0.5f;

    private Coroutine _incrementCoroutine;
    private int _count = 0;
    private bool _isCounting = false;
    private WaitForSeconds _waitInterval;

    private void Start()
    {
        _waitInterval = new WaitForSeconds(_updateInterval);
        _incrementCoroutine = StartCoroutine(Increment());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleCounting();
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting && _incrementCoroutine == null)
        {
            _incrementCoroutine = StartCoroutine(Increment());
        }
        else if (!_isCounting && _incrementCoroutine != null)
        {
            StopCoroutine(_incrementCoroutine);
            _incrementCoroutine = null;
        }
    }

    private void UpdateText()
    {
        _counterText.text = "—четчик: " + _count;
    }

    private IEnumerator Increment()
    {
        while (true)
        {
            yield return _waitInterval;
            if (_isCounting)
            {
                _count++;
                UpdateText();
            }
        }
    }
}

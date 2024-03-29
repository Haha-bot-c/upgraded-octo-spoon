using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Counter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text _counterText;
    [SerializeField] private float _updateInterval = 0.5f; 
    private bool _isCounting = false;
    private float _timeSinceLastUpdate = 0f;
    private int _count = 0;
    

    private void Start()
    {
        StartCoroutine(IncrementCounter());
    }

    private void Update()
    {
        if (_isCounting)
        {
            _timeSinceLastUpdate += Time.deltaTime;
            if (_timeSinceLastUpdate >= _updateInterval)
            {
                _count++;
                _timeSinceLastUpdate = 0f;
                UpdateText();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isCounting = !_isCounting;
    }

    private void UpdateText()
    {
        _counterText.text = "—четчик: " + _count;
    }

    private IEnumerator IncrementCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(_updateInterval);
            if (_isCounting)
            {
                _count++;
                UpdateText();
            }
        }
    }
}

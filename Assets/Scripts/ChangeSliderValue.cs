using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ChangeSliderValue : MonoBehaviour
{
    private Slider _slider;
    private Coroutine _changeValueCoroutine;
    private int _currentSliderValue;
    private int _minValue;
    private float _newValue;
    private float _oldValue;

    [SerializeField] private int _maxValue;
    [SerializeField] private float _lerpDuration;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    
    private void Start()
    {
        _newValue = _maxValue;
        _minValue = 0;
        _slider.maxValue = _maxValue;
        _slider.value = _maxValue;
    }
    
    public void OnButtonClickSliderValueChange(int newValue)
    {
        _oldValue = _newValue;
        _newValue = Mathf.Clamp(_oldValue + newValue, _minValue, _maxValue);
        if (_changeValueCoroutine != null)
        {
            StopCoroutine(_changeValueCoroutine);
        }
        _changeValueCoroutine = StartCoroutine(ChangeValue());
    }
    
    private IEnumerator ChangeValue()
    {
        float _timeElapsed = 0f;
        while(_timeElapsed <= _lerpDuration)
        {
            _slider.value = Mathf.Lerp(_oldValue, _newValue, _timeElapsed/_lerpDuration);
            _timeElapsed = Mathf.Clamp(_timeElapsed + Time.deltaTime, 0, _lerpDuration);
            yield return null;
        }
    }
}

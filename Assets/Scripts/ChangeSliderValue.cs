using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValue : MonoBehaviour
{
    private Slider _slider;
    private int _currentSliderValue;


    [SerializeField] private int _minValue, _maxValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _currentSliderValue = _maxValue;
        _slider.maxValue = _maxValue;
        _slider.value = _currentSliderValue;
    }

    public void OnButtonClickSliderValueChange(int newValue)
    {
        _currentSliderValue += newValue;
        _slider.value = Mathf.Clamp(_currentSliderValue, _minValue, _maxValue);
    }
}

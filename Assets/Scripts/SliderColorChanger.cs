using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SliderColorChanger : MonoBehaviour
{
    private Image _image;
    
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _lowHealthColor;
    [SerializeField] private Color _fullHealthColor;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    
    private void Update()
    {
        _image.color = Color.Lerp(_lowHealthColor, _fullHealthColor, _slider.value/_slider.maxValue);
    }
}

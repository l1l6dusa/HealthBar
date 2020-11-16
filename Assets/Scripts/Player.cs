using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator _animator;
    private UnityEvent<int> _onHealthChanged;
    
    [SerializeField] private Slider _slider;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _onHealthChanged = new UnityEvent<int>();
        _health = _maxHealth;
        _slider.maxValue = _maxHealth;
        _onHealthChanged.AddListener(_slider.GetComponent<ChangeSliderValue>().OnButtonClickSliderValueChange);
    }
    
    public void ChangeHealth(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, (int)_slider.maxValue);
        if (health < 0)
        {
            _animator.SetTrigger("Hit");
        }
        _onHealthChanged?.Invoke(health);
    }
}

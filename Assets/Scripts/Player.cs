using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    
    private Animator animator;
    private UnityEvent<int> OnHealthChanged;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        OnHealthChanged = new UnityEvent<int>();
        _health = _maxHealth;
        slider.maxValue = _maxHealth;
        OnHealthChanged.AddListener(slider.GetComponent<ChangeSliderValue>().OnButtonClickSliderValueChange);
    }
    public void ChangeHealth(int health)
    {
        _health = Mathf.Clamp(_health + health, 0, (int)slider.maxValue);
        if (health < 0)
        {
            animator.SetTrigger("Hit");
        }
        OnHealthChanged?.Invoke(health);
    }
}

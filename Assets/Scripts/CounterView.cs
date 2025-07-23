using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueIncreased += DisplayCounter;
    }

    private void OnDisable()
    {
        _counter.ValueIncreased -= DisplayCounter;
    }

    private void Start()
    {
        _text.text = "";
    }

    public void DisplayCounter()
    {
        _text.text = _counter.Count.ToString();
    }
}
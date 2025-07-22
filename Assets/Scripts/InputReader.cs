using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CounterView _counterView;

    public event Action Swiching;

    private void OnEnable()
    {
        Swiching += _counterView.Switch;
    }

    private void OnDisable()
    {
        Swiching -= _counterView.Switch;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Swiching.Invoke();
    }
}

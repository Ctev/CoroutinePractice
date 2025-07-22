using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterView _counterView;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private int _count;
    private event Action _isValueIncreased;

    public int Count => _count;

    private void OnEnable()
    {
        _isValueIncreased += _counterView.DisplayCounter;
    }

    private void OnDisable()
    {
        _isValueIncreased -= _counterView.DisplayCounter;
    }

    private void Start()
    {
        _count = 0;
    }

    public void Switch()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(ValueIncreasing());
        }
    }

    private IEnumerator ValueIncreasing()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        bool isWork = true;

        while (isWork)
        {
            _count++;
            _isValueIncreased.Invoke();

            yield return wait;
        }
    }
}

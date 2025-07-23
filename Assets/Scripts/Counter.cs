using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;

    public int Count { get; private set; }
    public event Action ValueIncreased;

    private void OnEnable()
    {
        _inputReader.Switched += Switch;
    }

    private void OnDisable()
    {
        _inputReader.Switched -= Switch;
    }

    private void Start()
    {
        Count = 0;
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
            Count++;
            ValueIncreased.Invoke();

            yield return wait;
        }
    }
}
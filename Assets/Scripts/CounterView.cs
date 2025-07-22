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
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private int _count;
    private bool _isWork;

    public void Switch()
    {
        _isWork = !_isWork;

        if (_isWork)
            _coroutine = StartCoroutine(ValueIncreasing());
        else
            StopCoroutine(_coroutine);
    }

    private void Start()
    {
        _text.text = "";
        _count = 0;
        _isWork = false;
    }

    private IEnumerator ValueIncreasing()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isWork)
        {
            _count++;
            DisplayCounter(_count);

            yield return wait;
        }
    }

    private void DisplayCounter(int count)
    {
        _text.text = count.ToString();
    }
}

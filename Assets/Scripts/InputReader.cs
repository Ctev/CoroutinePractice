using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private event Action _switched;

    private void OnEnable()
    {
        _switched += _counter.Switch;
    }

    private void OnDisable()
    {
        _switched -= _counter.Switch;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _switched.Invoke();
    }
}

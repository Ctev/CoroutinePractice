using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action Switched;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Switched.Invoke();
    }
}
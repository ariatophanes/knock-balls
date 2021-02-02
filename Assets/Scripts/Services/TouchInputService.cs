using System;
using UnityEngine;
using Zenject;

public class TouchInputService : IInputService
{
    public event Action<Vector3> onAttack;

    public void Tick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        onAttack?.Invoke(Input.mousePosition);

    }
}
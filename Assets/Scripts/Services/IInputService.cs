using System;
using UnityEngine;
using Zenject;

public interface IInputService : ITickable
{
    event Action<Vector3> onAttack;
}
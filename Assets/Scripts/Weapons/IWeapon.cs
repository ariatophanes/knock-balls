using System;
using UnityEngine;

public interface IWeapon
{
    int AttacksCount { get; set; }
    void Attack(Vector3 dir);

    event Action onAttack;
}
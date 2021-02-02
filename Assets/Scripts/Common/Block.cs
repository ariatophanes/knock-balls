using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action onFall;

    private const float boundY = 1.3f;

    private bool isFallen;

    private void Update()
    {
        if (transform.position.y > boundY) return;

        if (isFallen) return;

        isFallen = true;
        
        onFall?.Invoke();
    }
}

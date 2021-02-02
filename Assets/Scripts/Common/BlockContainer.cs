using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlockContainer : MonoBehaviour
{
    public event Action onAllBlocksFell;
    public List<Block> Blocks;

    private int fallenBlocksCount;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        for (int i = 0; i < Blocks.Count; i++)
        {
            Blocks[i].onFall += HandleBlockFall;
        }
    }

    private void Unsubscribe()
    {
        for (int i = 0; i < Blocks.Count; i++)
        {
            Blocks[i].onFall -= HandleBlockFall;
        }
    }

    private void HandleBlockFall()
    {
        fallenBlocksCount++;

        if (fallenBlocksCount != Blocks.Count) return;
        
        onAllBlocksFell?.Invoke();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
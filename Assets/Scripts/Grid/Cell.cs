using Conway;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cell
{
    public TileBase tileBase { get; set; }
    public CellState state;
    public AudioClip sound;

    public Cell()
    {
        state = CellState.Dead;
    }

    public bool isAlive()
    {
        if(state == CellState.Alive)
        {
            return true;
        }
        return false;
    }

    public void PlaySound()
    {
        if(sound != null)
        {
            AudioManager.Instance.Play(sound);
        }
        else
        {
            Debug.LogError("Sound not found");
        }
    }
}

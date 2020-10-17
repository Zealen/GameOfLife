using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileSet : ScriptableObject
{
    public TileBase locked;
    public TileBase border;
    public TileBase highlight;
    public TileBase dead;
    public TileBase alive;
}

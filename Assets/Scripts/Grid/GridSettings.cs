using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class GridSettings : ScriptableObject
{
    public int height;
    public int width;
    public int edgeBuffer;
}

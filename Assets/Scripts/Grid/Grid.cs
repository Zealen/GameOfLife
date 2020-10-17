using Conway;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Grid : MonoBehaviour
{
    [SerializeField]
    public TileBase defaultTile;

    private Tilemap map;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        DrawDefaultTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void DrawDefaultTile()
    {
        foreach (Vector3Int position in map.cellBounds.allPositionsWithin)
        {
            map.SetTile(position, defaultTile);
        }
    }
}

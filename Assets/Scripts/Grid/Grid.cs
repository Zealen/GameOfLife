using Conway;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Grid : MonoBehaviour
{
    [SerializeField]
    public TileBase red;
    [SerializeField]
    public TileBase black;
    [SerializeField]
    public TileBase highlight;
    [SerializeField]
    public TileBase white;
    [SerializeField]
    public TileBase green;
    [SerializeField]
    public TileBase purple;

    private Tilemap map;
    private Cell[,] cells;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        cells = new Cell[map.size.x, map.size.y];
        GenerateCells();
    }

    // Update is called once per frame
    void Update()
    {
        map.SetTile(new Vector3Int(), red);
        map.SetTile(new Vector3Int(0, 0, 2), highlight);

    }

    private void GenerateCells()
    {
        foreach (Vector3Int position in map.cellBounds.allPositionsWithin)
        {
            cells[position.x, position.y] = new Cell();
            map.SetTile(position, black);
        }
    }

    public Cell GetCell(Vector3Int position)
    {
        return cells[position.x, position.y];
    }

    public void UpdateCell(Vector3Int position, TileBase tile)
    {
        if (IsValidCoordinate((position.x, position.y), map.size.x, map.size.y))
        {
            map.SetTile(position, tile);
            cells[position.x, position.y].tileBase = tile;
            if (tile == purple)
            {
                cells[position.x, position.y].state = CellState.Alive;
            }
        }
    }

    public int GetNeighbourhoodSum(Vector3Int position)
    {
        int result = 0;
        foreach(var neighbour in GetAllNeighbouringCoordinates(position.x, position.y))
        {
            if (IsValidCoordinate((position.x, position.y), map.size.x, map.size.y))
            {
                if (cells[position.x, position.y].isAlive())
                {
                    result++;
                }
            }
        }
        return result;
    }

    private static IEnumerable<(int Row, int Column)> GetAllNeighbouringCoordinates(int row, int column)
    {
        yield return (row - 1, column - 1);
        yield return (row - 1, column);
        yield return (row - 1, column + 1);
        yield return (row, column + 1);
        yield return (row + 1, column + 1);
        yield return (row + 1, column);
        yield return (row + 1, column - 1);
        yield return (row, column - 1);
    }

    private static bool IsValidCoordinate((int Row, int Column) position, int rowCount, int columnCount)
    {
        if (0 > position.Row || position.Row >= rowCount ||
            0 > position.Column || position.Column >= columnCount)
            return false;

        return true;
    }
}

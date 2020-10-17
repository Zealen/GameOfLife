using Conway;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellContainer : MonoBehaviour
{
    [SerializeField]
    public TileSet tileSet;

    private Tilemap map;
    private Cell[,] cells;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        cells = new Cell[map.size.x, map.size.y];
        GenerateCells();
        AssignNotes();
        StartCoroutine(UpdateAllCellStates());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AssignNotes()
    {

    }

    private void GenerateCells()
    {
        foreach (Vector3Int position in map.cellBounds.allPositionsWithin)
        {
            cells[position.x, position.y] = new Cell() { tileBase = tileSet.dead };
            map.SetTile(position, tileSet.dead);
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
            if (tile == tileSet.alive || tile == tileSet.locked)
            {
                cells[position.x, position.y].tileBase = tile;
                cells[position.x, position.y].state = CellState.Alive;
            }
            else if (tile == tileSet.dead)
            {
                cells[position.x, position.y].tileBase = tile;
                cells[position.x, position.y].state = CellState.Dead;
            }
        }
    }

    public IEnumerator UpdateAllCellStates()
    {
        while (true)
        {
            Cell[,] tempCells = new Cell[map.size.x, map.size.y];
            //Copy the Cell map and get rid of the highlight layer
            //map.size = new Vector3Int(map.size.x, map.size.y, 1);
            //map.ResizeBounds();
            foreach (Vector2Int position in map.cellBounds.allPositionsWithin)
            {
                tempCells[position.x, position.y] = new Cell()
                {
                    tileBase = cells[position.x, position.y].tileBase,
                    state = ConwayRules.GetCellState(cells[position.x, position.y].state, GetNeighbourhoodSum(position))
                };
                //Force Cell to stay in alive state
                if (tempCells[position.x, position.y].tileBase == tileSet.locked)
                {
                    tempCells[position.x, position.y].tileBase = tileSet.locked;
                    tempCells[position.x, position.y].state = CellState.Alive;

                }
                else if (tempCells[position.x, position.y].isAlive())
                {
                    tempCells[position.x, position.y].tileBase = tileSet.alive;
                    map.SetTile(new Vector3Int(position.x, position.y, 0), tileSet.alive);
                }
                else
                {
                    tempCells[position.x, position.y].tileBase = tileSet.dead;
                    map.SetTile(new Vector3Int(position.x, position.y, 0), tileSet.dead);
                }
            }
            cells = tempCells;
            yield return new WaitForSeconds(3);
        }

    }

    private int GetNeighbourhoodSum(Vector2Int position)
    {
        int result = 0;
        foreach (var neighbour in GetAllNeighbouringCoordinates(position.x, position.y))
        {
            if (IsValidCoordinate((neighbour.x, neighbour.y), map.size.x, map.size.y))
            {
                if (cells[neighbour.x, neighbour.y].isAlive())
                {
                    result++;
                }
            }
        }
        return result;
    }

    private static IEnumerable<(int x, int y)> GetAllNeighbouringCoordinates(int row, int column)
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

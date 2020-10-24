using Conway;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellContainer : MonoBehaviour
{
    [SerializeField]
    public TileSet tileSet;
    [SerializeField]
    public AudioData audioSet;
    public GameObject tileAnimation;

    private Tilemap map;
    private Cell[,] cells;
    private int stepCount;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        cells = new Cell[map.size.x, map.size.y];
        stepCount = 0;
        GenerateCells();
        AssignNotes();
        StartCoroutine(PlayChords());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayChords()
    {
        while (true)
        {
            for (int row = 0; row < map.size.y; row++)
            {
                if (cells[stepCount, row].isAlive())
                {
                    //Play Sounds
                    cells[stepCount, row].PlaySound();
                    //Play Animations
                    Instantiate(tileAnimation, new Vector3(stepCount + map.tileAnchor.x, row + map.tileAnchor.y), Quaternion.identity);
                    //GameObject myRoadInstance = Instantiate(Resources.Load("Prefab/GameObject")) as GameObject;
                    //Destroy(myRoadInstance.GetComponent< UnityEngine.Experimental.Rendering.>(), 2);
                    //Destroy(myRoadInstance, 3);
                }
            }
            stepCount++;
            if (stepCount >= map.size.x)
            {
                stepCount = 0;
                UpdateAllCellStates();
            }

            yield return new WaitForSeconds(audioSet.bpm);
        }
    }

    private void AssignNotes()
    {
        for (int col = 0; col < map.size.x; col++)
        {
            for (int row = 0; row < map.size.y; row++)
            {
                // Check if there are enough sounds for each row
                if (audioSet.sounds.Count >= row)
                {
                    cells[col, row].sound = audioSet.sounds[row];
                }
            }
        }
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
        if (IsValidCoordinate((position.x, position.y), map.size.x, map.size.y))
            return cells[position.x, position.y];
        return null;
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

    public void UpdateAllCellStates()
    {
        Cell[,] tempCells = new Cell[map.size.x, map.size.y];

        foreach (Vector2Int position in map.cellBounds.allPositionsWithin)
        {
            tempCells[position.x, position.y] = new Cell()
            {
                tileBase = cells[position.x, position.y].tileBase,
                state = ConwayRules.GetCellState(cells[position.x, position.y].state, GetNeighbourhoodSum(position)),
                sound = cells[position.x, position.y].sound
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

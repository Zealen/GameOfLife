using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CellContainer))]
public class GridController : MonoBehaviour
{

    private Tilemap map;
    private CellContainer cells;
    private Vector3Int cellPosition;
    private Vector3Int previousCellPosition;
    private TileBase clickedTile;

    private Vector3 mousePos;
    private Vector3 mouseWorldPos;

    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        cells = gameObject.GetComponent<CellContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        cellPosition = map.WorldToCell(mouseWorldPos);

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            clickedTile = null;
        }

        ClickCell(Input.GetMouseButton(0), cells.tileSet.alive);
        ClickCell(Input.GetMouseButton(1), cells.tileSet.locked);
        HighlightCell();
    }

    private void ClickCell(bool input, TileBase tile)
    {
        Cell cell = cells.GetCell(cellPosition);
        if (input && cell != null)
        {
            if(clickedTile == null)
            {
                clickedTile = cell.tileBase;
            }

            if (clickedTile == cells.tileSet.dead)
            {
                cells.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 0), tile);
            }
            else
            {
                cells.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 0), cells.tileSet.dead);
            }
        }
    }

    private void HighlightCell()
    {
        if (cellPosition != previousCellPosition)
        {
            cells.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 1), cells.tileSet.highlight);
            cells.UpdateCell(new Vector3Int(previousCellPosition.x, previousCellPosition.y, 1), null);
            previousCellPosition = cellPosition;
        }
    }
}

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

    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        cells = gameObject.GetComponent<CellContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        cellPosition = map.WorldToCell(mouseWorldPos);

        ClickCell(Input.GetMouseButtonDown(0), cells.tileSet.alive);
        ClickCell(Input.GetMouseButtonDown(1), cells.tileSet.locked);
        HighlightCell();
    }

    private void ClickCell(bool input, TileBase tile)
    {
        if (input)
        {
            Cell cell = cells.GetCell(cellPosition);
            if (cells.GetCell(cellPosition).tileBase == tile)
            {
                cells.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 0), cells.tileSet.dead);
            }
            else 
            {
                cells.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 0), tile);
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

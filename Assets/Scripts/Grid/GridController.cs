using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{

    private Tilemap map;
    private Grid grid;
    private Vector3Int cellPosition;
    private Vector3Int previousCellPosition;

    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        grid = gameObject.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        cellPosition = map.WorldToCell(mouseWorldPos);

        HighlightCell();
        LeftClickCell();
    }

    private void LeftClickCell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cell cell = grid.GetCell(cellPosition);
            if (grid.GetCell(cellPosition).tileBase == grid.purple)
            {
                grid.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 0), grid.black);
            }
            else
            {
                grid.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 0), grid.purple);
            }
            
        }
    }

    private void HighlightCell()
    {
        if (cellPosition != previousCellPosition)
        {
            grid.UpdateCell(new Vector3Int(cellPosition.x, cellPosition.y, 1), grid.highlight);
            grid.UpdateCell(new Vector3Int(previousCellPosition.x, previousCellPosition.y, 1), null);
            previousCellPosition = cellPosition;
        }
    }
}

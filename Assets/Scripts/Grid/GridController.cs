using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{

    public Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3Int coordinate = map.WorldToCell(mouseWorldPos);
        Debug.Log(coordinate);
        Debug.Log(mouseWorldPos);


        if (Input.GetMouseButtonDown(0))
        {
            var tile = map.GetTile(coordinate);
        }
    }
}

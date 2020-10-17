using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public GridSettings settings;

    void Awake()
    {
        Tilemap[] tileMaps = GetComponentsInChildren<Tilemap>();
        foreach (Tilemap tileMap in tileMaps)
        {
            tileMap.size =  new Vector3Int(settings.width, settings.height, 1);
        }

        AdjustCamera();
    }

    private void AdjustCamera()
    {
        //Change the camera to adjust to grid size
        Camera.main.transform.position = new Vector3(settings.width / 2, settings.height / 2, -(Mathf.Tan((180 - Camera.main.fieldOfView) / 2 * Mathf.Deg2Rad) * ((settings.width + settings.edgeBuffer) / 2)));
    }



}

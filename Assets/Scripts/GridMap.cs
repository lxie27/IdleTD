using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GridMap : MonoBehaviour
{
    public Grid grid;
    public Tilemap path;
    List<Vector3> pathCells;

    void Start()
    {
        //path = GetComponent("Tilemap_Path") as Tilemap;
        if (!path)
        {
            Debug.Log("Path was not found, did you name the path tilemap 'Tilemap_Path'?");
        }
        else
        {
            pathCells = GetCellsFromTilemap(path);
            foreach (var cell in pathCells)
            {
                Debug.Log("Cell: " + cell.x + ", " + cell.y);
            }
        }
    }

    void Update()
    {

    }

    List<Vector3> GetCellsFromTilemap(Tilemap tilemap)
    {
        List<Vector3> worldPosCells = new List<Vector3>();
        foreach (var boundInt in tilemap.cellBounds.allPositionsWithin)
        {
            //Get the local position of the cell
            Vector3Int relativePos = new Vector3Int(boundInt.x, boundInt.y, boundInt.z);
            //Add it to the List if the local pos exist in the Tile map
            if (tilemap.HasTile(relativePos))
            {
                //Convert to world space
                Vector3 worldPos = tilemap.CellToWorld(relativePos);
                worldPosCells.Add(worldPos);
            }
        }
        return worldPosCells;
    }
}

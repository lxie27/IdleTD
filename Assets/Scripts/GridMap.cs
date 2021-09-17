using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GridMap : MonoBehaviour
{
    public Grid grid;
    public Tilemap path;
    public List<Vector2> pathCells;
    List<Mob> mobs;

    void Awake()
    {
        //path = GetComponent("Tilemap_Path") as Tilemap;
        if (!path)
        {
            Debug.Log("Path was not found, did you name the path tilemap 'Tilemap_Path'?");
        }
        else
        {
            pathCells = ConvertToPath(GetCellsFromTilemap(path));
        }
    }

    void Update()
    {
        
    }

    List<Vector2> GetCellsFromTilemap(Tilemap tilemap)
    {
        List<Vector2> worldPosCells = new List<Vector2>();
        foreach (var boundInt in tilemap.cellBounds.allPositionsWithin)
        {
            //Get the local position of the cell
            Vector2Int relativePos = new Vector2Int(boundInt.x, boundInt.y);
            //Add it to the List if the local pos exist in the Tile map
            if (tilemap.HasTile((Vector3Int)relativePos))
            {
                //Convert to world space
                Vector2 worldPos = tilemap.GetCellCenterWorld((Vector3Int)relativePos);
                worldPosCells.Add(worldPos);
            }
        }
        return worldPosCells;
    }

    //  Reorders a given tilemap to create a path starting from given point
    //  Assumptions: path starts at pathCells[0] and each connected tile is <= 1.0f units away
    List<Vector2> ConvertToPath(List<Vector2> pathCells)
    {
        List<Vector2> orderedPath = new List<Vector2>();

        
        //  TODO this is sketchy for programmatically generating paths in the future
        orderedPath.Add(pathCells[0]);
        pathCells.RemoveAt(0);
        int nextCell = 1;
        
        while (pathCells.Count > 0)
        {
            if(nextCell > (pathCells.Count-1))
            {
                nextCell = 0;
            }

            Vector2 prevCell = orderedPath[orderedPath.Count-1];
            if (Vector2.Distance(pathCells[nextCell], prevCell) == 1f)
            {
                orderedPath.Add(pathCells[nextCell]);
                pathCells.RemoveAt(nextCell);
            }
            else 
            {
                nextCell++;
            }
        }
        
        return orderedPath;
    }
}

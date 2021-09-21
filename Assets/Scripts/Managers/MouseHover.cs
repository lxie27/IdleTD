using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseHover : MonoBehaviour
{
    Vector2Int mousePos;
    Vector2Int previousPos;

    Grid grid;
    GridMap gridmap;
    public Tilemap interactableTiles;
    Tilemap interactableTilesCopy;
    Color original = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        grid = this.gameObject.GetComponent<Grid>();
        gridmap = grid.GetComponent<GridMap>();
        interactableTilesCopy = interactableTiles;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        mousePos = GetMousePosition();
        Tile highlightedTile;
        if (interactableTiles.cellBounds.Contains((Vector3Int)mousePos))
        {
            if (mousePos != previousPos)
            {
                highlightedTile = interactableTiles.GetTile<Tile>((Vector3Int)mousePos);

                if (highlightedTile != null)
                {
                    Tile originalTile = interactableTilesCopy.GetTile<Tile>((Vector3Int)mousePos);
                    //Reset previous tile
                    SetTileColor(original, previousPos, interactableTiles);

                    //Highlight current tile

                    Color highlight = new Color(1f, .92f, .016f, 1f);
                    SetTileColor(highlight, mousePos, interactableTiles);

                    previousPos = mousePos;
                }
            }
        }
        else
        {
            highlightedTile = null;
        }
    }

    Vector2Int GetMousePosition()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (Vector2Int)grid.WorldToCell(mouseWorldPos);
    }
    private void SetTileColor(Color c, Vector2Int position, Tilemap tm)
    {
        tm.SetTileFlags((Vector3Int)position, TileFlags.None);
        tm.SetColor((Vector3Int)position, c);
    }
}

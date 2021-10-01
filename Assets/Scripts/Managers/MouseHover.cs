using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseHover : MonoBehaviour
{
    public Vector2Int mousePos;
    Vector2Int previousPos;

    Grid grid;
    public Tilemap interactableTiles;
    public Tilemap towerTiles;

    Color validColor = new Color(.06f, .89f, 1f, 1f);
    Color invalidColor = new Color(.8f, 0f, 0f, 1f);
    Color originalColor = Color.white;

    public Tile highlightedTile;

    // Start is called before the first frame update
    void Start()
    {
        grid = this.gameObject.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        mousePos = GetMousePosition();

        // Mouse is in the box of possible interactable cells
        if (interactableTiles.cellBounds.Contains((Vector3Int)mousePos))
        {
            //  Mouse has been moved
            if (mousePos != previousPos)
            {
                highlightedTile = interactableTiles.GetTile<Tile>((Vector3Int)mousePos);

                //  Mouse is over a tile that is in interactableTiles
                if (interactableTiles.ContainsTile(highlightedTile))
                {
                    if (highlightedTile != null)
                    {
                        SetTileColor(originalColor, previousPos, interactableTiles);
                        SetTileColor(validColor, mousePos, interactableTiles);
                    }
                }
                else
                {
                    SetTileColor(originalColor, previousPos, interactableTiles);
                    highlightedTile = null;
                }

                previousPos = mousePos;
            }
        }
        else
        {
            SetTileColor(originalColor, previousPos, interactableTiles);
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

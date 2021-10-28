using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SelectionModes
{
    None = 0,
    Select = 1,
    PlaceTowers = 2
}

public class TowerPlacer : MonoBehaviour
{
    MouseHover mouse;
    public Dictionary<Tuple<int, int>, GameObject> towersOnMap;
    public SelectionModes currentMode;
    GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        currentMode = 0;

        if (towersOnMap == null)
        {
            towersOnMap = new Dictionary<Tuple<int, int>, GameObject>();
        }

        mouse = gameObject.GetComponent<MouseHover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //If we clicked on a game object
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //this check is kinda just for dodging an error
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    if (EventSystem.current.currentSelectedGameObject.tag == "TowerSelectionButton")
                    {
                        currentMode = SelectionModes.PlaceTowers;
                        selectedObject = EventSystem.current.currentSelectedGameObject;
                    }
                }
            }

            else
            {
                switch(currentMode)
                {
                    case SelectionModes.None:
                        break;
                    case SelectionModes.Select:
                        break;
                    case SelectionModes.PlaceTowers:
                        PlaceTower(selectedObject.
                            GetComponent<SelectTowerButton>().towerSlot.
                            GetComponent<TowerSlot>().towerModel);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void PlaceTower(TowerModel _model)
    {
        if (mouse.highlightedTile != null)
        {
            var mouseCoords = new Tuple<int, int>(mouse.mousePos.x, mouse.mousePos.y);
            if (!towersOnMap.ContainsKey(mouseCoords))
            {
                towersOnMap.Add(mouseCoords, TowerFactory.Spawn(new Vector2(mouse.mousePos.x + 0.5f, mouse.mousePos.y + 0.5f), _model));
                currentMode = SelectionModes.None; 
            }
        }
    }
}

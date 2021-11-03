using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SelectionModes
{
    None = 0,
    Select = 1,
    PlaceTowers = 2
}

public class TowerPlacer : MonoBehaviour
{
    public GameObject   towerDisplay;
    public Text         towerSummary;

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
                        selectedObject = EventSystem.current.currentSelectedGameObject;
                        currentMode = SelectionModes.PlaceTowers;
                        DisplayTowerPreview();
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

    void DisplayTowerPreview()
    {
        UndisplayTowerPreview();

        TowerSlot selectedTowerSlot = selectedObject.
            GetComponent<SelectTowerButton>().towerSlot.
            GetComponent<TowerSlot>();
        GameObject towerPreview = selectedTowerSlot.GenerateTowerPreview();
        TowerModel towerModel = selectedTowerSlot.towerModel;

        //Tower image preview
        Utils.SetLayerRecursively(towerPreview, 5); //layer 5 is UI
        towerPreview.transform.parent = towerDisplay.transform;
        towerPreview.transform.localPosition = new Vector2(0, -30f);
        towerPreview.transform.localScale = new Vector2(75, 75);

        // Tower summary in text
        towerSummary.text += towerModel.name + "\n";
        towerSummary.text += "Damage: " + towerModel.damage.ToString() + "\n";
        towerSummary.text += "Radius: " + towerModel.radius.ToString() + "\n";
        towerSummary.text += "Attack Speed: " + towerModel.attackSpeed.ToString() + "\n";
        towerSummary.text += "Type: " + towerModel.type + "\n";
    }

    void UndisplayTowerPreview()
    {
        if (towerDisplay.transform.childCount > 0)
        {
            foreach (Transform child in towerDisplay.transform)
            {
                Destroy(child.gameObject);
            }
        }

        towerSummary.text = "";
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

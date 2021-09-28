using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacer : MonoBehaviour
{
    MouseHover mouse;
    public Dictionary<Tuple<int, int>, GameObject> towersOnMap;

    // Start is called before the first frame update
    void Start()
    {
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
            //do button stuff
            if (EventSystem.current.IsPointerOverGameObject())
            {

            }
            //otherwise do gameobject stuff
            else if (mouse.highlightedTile != null)
            {
                var mouseCoords = new Tuple<int, int>(mouse.mousePos.x, mouse.mousePos.y);
                if (!towersOnMap.ContainsKey(mouseCoords))
                {
                    towersOnMap.Add(mouseCoords, TowerFactory.Spawn(new Vector2(mouse.mousePos.x + 0.5f, mouse.mousePos.y + 0.5f)));
                }
            }
        }
    }
}

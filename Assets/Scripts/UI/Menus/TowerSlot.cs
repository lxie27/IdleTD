using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    public TowerModel   towerModel;
    public Sprite       towerIcon;
    public GameObject   selectTowerButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTowerToSlot(TowerModel _tower)
    {
        this.towerModel = _tower;
        Display();
    }

    
    //Show the tower icon in inventory and sets button to active (selectable)
    public void Display()
    {
        if (towerModel != null)
        {
            GameObject tower = gameObject.transform.Find("TowerIcon").gameObject;
            tower.GetComponent<Image>().sprite =
                Utils.GetIconFromTowerModel(towerModel);
            tower.GetComponent<Image>().color = Color.white;
        }
        selectTowerButton.SetActive(true);
    }

    public GameObject GenerateTowerPreview()
    {
        //  Create the tower object to get the gem, projectilesource, and base sprites together
        GameObject towerPreview = TowerFactory.Spawn(new Vector2(0, 0), towerModel);

        //  Send object to be stripped down to sprite and transform
        towerPreview = GetPreviewFromGameObject(towerPreview);
        return towerPreview;
    }

    // Strips the transform and spriterenderer from gameobject for lightweight preview 
    GameObject GetPreviewFromGameObject(GameObject go)
    {
        Component[] components = go.GetComponents(typeof(Component));

        foreach (Component comp in components)
        {
            if (!(comp is Transform || comp is SpriteRenderer))
            {
                Object.Destroy(comp);
            }
        }
        
        return go;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    public TowerModel towerData;
    public Sprite towerIcon;

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
        this.towerData = _tower;
        Display();
    }

    public void Display()
    {
        if (towerData != null)
        {
            GameObject tower = gameObject.transform.Find("Tower").gameObject;
            tower.GetComponent<Image>().sprite =
                Utils.GetIconFromTowerModel(towerData);
            tower.GetComponent<Image>().color = Color.white;
        }
    }
}

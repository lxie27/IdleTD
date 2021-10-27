using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    public TowerModel towerModel;
    public Sprite towerIcon;
    public GameObject selectTowerButton;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTowerButton : MonoBehaviour
{
    public GameObject towerSlot;
    public Button selectTowerButton;

    // Start is called before the first frame update
    void Start()
    {
        selectTowerButton.onClick.AddListener(() => { SelectTower(); });
    }

    public TowerModel SelectTower()
    {
        return this.gameObject.GetComponentInParent<TowerSlot>().towerData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

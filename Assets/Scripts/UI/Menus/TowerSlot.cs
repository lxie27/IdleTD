using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour
{
    public Tower tower;
    public Sprite towerIcon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTowerToSlot(Tower tower)
    {
        this.tower = tower;
        Display();
    }

    public void Display()
    {
        if (tower != null)
        {
            Texture2D towerTexture = tower.GetPreviewTexture();
            Sprite towerSprite = Sprite.Create(towerTexture, new Rect(0,0,towerTexture.width, towerTexture.height), new Vector2(0, 0));
            gameObject.GetComponentInChildren<Image>().sprite = towerSprite;
        }
        else
        {
            gameObject.GetComponentInChildren<Image>().sprite = null;
        }
    }
}

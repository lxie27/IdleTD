using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerInventoryMenu : MonoBehaviour
{
    public float slotsStartingX, slotsStartingY;
    public float rightSpacing, bottomSpacing;
    public int rows, cols;

    public List<TowerData> towersInInventory;
    public TowerSlot slot;
    public GameObject slotsParent;

    List<TowerSlot> slots = new List<TowerSlot>();

    // Start is called before the first frame update
    void Start()
    {
        towersInInventory = GameManager.playerData.towerInventory;
        SetSlots(rows, cols);
        PutTowersInSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //SaveLoad.currentPlayer.towerInventory
    public static List<Sprite> GetAllIconsFromData(List<TowerData> allTowerData)
    {
        List<Sprite> temp = new List<Sprite>();
        foreach (var td in allTowerData)
        {
            temp.Add(GetTowerIconFromData(td));
        }
        return temp;
    }

    public static Sprite GetTowerIconFromData(TowerData td)
    {
        switch (td.type)
        {
            case TowerType.Basic:
                Texture2D tempTexture = AssetPreview.GetAssetPreview(
                    AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Towers/BaseTower", typeof(GameObject)));
                return Sprite.Create(tempTexture, new Rect(0, 0, tempTexture.width, tempTexture.height), Vector2.zero);
            default:
                return null;
        }
    }
    void SetSlots(int rows, int cols)
    {
        float slotHeight = slot.GetComponent<RectTransform>().rect.height;
        float slotWidth = slot.GetComponent<RectTransform>().rect.width;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                TowerSlot s = Instantiate(slot, this.transform, false);

                float x = slotsStartingX + (col * (slotWidth + rightSpacing));
                float y = slotsStartingY - (row * (slotHeight + bottomSpacing));
                s.transform.localPosition = new Vector2(x, y);
                s.transform.SetParent(slotsParent.transform);

                slots.Add(s);
            }
        }
    }

    void PutTowersInSlots()
    {
        //int i = 0;
        Debug.Log(towersInInventory.Count + " towers in save file");
        foreach (var tower in towersInInventory)
        {
            //slots[i].AddTowerToSlot(tower);
        }
    }
}

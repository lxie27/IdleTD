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

    public List<TowerModel> towersInInventory;
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
        for (int i = 0; i < towersInInventory.Count; i++)
        {
            slots[i].AddTowerToSlot(towersInInventory[i]);
        }
    }
}

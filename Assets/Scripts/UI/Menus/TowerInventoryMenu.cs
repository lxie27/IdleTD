using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInventoryMenu : MonoBehaviour
{ 
    public float slotsStartingX, slotsStartingY;
    public float rightSpacing, bottomSpacing;
    public int rows, cols;

    public List<GameObject> towersInInventory;
    public GameObject slot;
    public GameObject slotsParent;


    //bool presetSlotOrder = true;



    // Start is called before the first frame update
    void Start()
    {
        SetSlots(rows, cols);
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
                GameObject s = Instantiate(slot, this.transform, false);

                float x = slotsStartingX + (col * (slotWidth + rightSpacing));
                float y = slotsStartingY - (row * (slotHeight + bottomSpacing));
                s.transform.localPosition = new Vector2(x, y);
                s.transform.SetParent(slotsParent.transform);

            }
        }
    }
}

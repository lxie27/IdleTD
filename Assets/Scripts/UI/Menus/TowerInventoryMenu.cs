using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TowerInventoryMenu : MonoBehaviour
{
    public float slotsStartingX, slotsStartingY;
    public float rightSpacing, bottomSpacing;
    public int rows, cols;

    public List<TowerModel> towersInInventory;
    public TowerSlot slot;
    public GameObject slotsParent;              //used to nicely group towerslots

    public GameObject towerPreviewDisplay;
    public Text towerPreviewSummary;
    public List<GameObject> stars;

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
    public void DisplayTowerPreview(TowerSlot selectedTowerSlot)
    {
        UndisplayTowerPreview();

        GameObject towerPreview = selectedTowerSlot.GenerateTowerPreview();
        TowerModel towerModel = selectedTowerSlot.towerModel;

        //Tower image preview
        Utils.SetLayerRecursively(towerPreview, 5); //layer 5 is UI
        towerPreview.transform.parent = towerPreviewDisplay.transform;
        towerPreview.transform.localPosition = new Vector2(0, -30f);
        towerPreview.transform.localScale = new Vector2(75, 75);

        // Tower summary in text
        towerPreviewSummary.text += "\n";
        towerPreviewSummary.text += towerModel.name + "\n";
        towerPreviewSummary.text += "Damage: " + towerModel.damage.ToString("F2") + "\n";
        towerPreviewSummary.text += "Radius: " + towerModel.radius.ToString("F2") + "\n";
        towerPreviewSummary.text += "Attack Speed: " + towerModel.attackSpeed.ToString("F2") + "\n";
        towerPreviewSummary.text += "Type: " + towerModel.type + "\n";
        
        foreach (GameObject star in stars)
        {
            star.SetActive(true);
        }

        for (int s = 0; s < towerModel.stars; s++)
        {
            stars[s].GetComponent<Image>().color = Color.white;
        }
    }

    public void UndisplayTowerPreview()
    {
        if (towerPreviewDisplay.transform.childCount > 0)
        {
            foreach (Transform child in towerPreviewDisplay.transform)
            {
                Destroy(child.gameObject);
            }
        }

        towerPreviewSummary.text = "";

        foreach(GameObject star in stars)
        {
            star.SetActive(false);
            star.GetComponent<Image>().color = Color.black;
        }
    }
}

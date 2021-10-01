using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public List<TowerData> towerInventory;
    public List<GemData> gemInventory;
    public float currency;

    public PlayerData()
    {
        towerInventory = new List<TowerData>();
        gemInventory = new List<GemData>();
        currency = 0;
    }

    public PlayerData CreateDevSaveData()
    {
        PlayerData save = new PlayerData();

        TowerData td1 = new TowerData();
        TowerData td2 = new TowerData();
        TowerData td3 = new TowerData();
        TowerData td4 = new TowerData();
        TowerData td5 = new TowerData();
        save.towerInventory.Add(td1);
        save.towerInventory.Add(td2);
        save.towerInventory.Add(td3);
        save.towerInventory.Add(td4);
        save.towerInventory.Add(td5);

        GemData gem1 = new GemData();
        gem1.rarity = Rarity.Mythical;

        save.currency += 999;

        return save;
    }

    public PlayerData CreateSaveData()
    {
        PlayerData save = new PlayerData();

        foreach (TowerData tower in towerInventory)
        {
            save.towerInventory.Add(tower);
        }
        foreach (GemData gem in gemInventory)
        {
            save.gemInventory.Add(gem);
        }

        return save;
    }
}
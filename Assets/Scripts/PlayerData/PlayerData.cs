using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public List<TowerModel> towerInventory;
    public List<GemData> gemInventory;
    public float currency;

    public PlayerData()
    {
        towerInventory = new List<TowerModel>();
        gemInventory = new List<GemData>();
        currency = 0;
    }

    public static PlayerData CreateDevSaveData()
    {
        PlayerData save = new PlayerData();

        TowerModel t1 = TowerModel.Factory.CreateTowerModel();
        GemData gem1 = new GemData();
        gem1.rarity = Rarity.Mythical;
        save.towerInventory.Add(t1);
        t1.gemsData.Add(gem1);

        TowerModel t2 = TowerModel.Factory.CreateTowerModel();
        GemData gem2 = new GemData();
        gem1.rarity = Rarity.Mythical;
        save.towerInventory.Add(t2);
        t1.gemsData.Add(gem1);

        save.currency += 999;

        return save;
    }

    public PlayerData CreateSaveData()
    {
        PlayerData save = new PlayerData();

        foreach (TowerModel tower in towerInventory)
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
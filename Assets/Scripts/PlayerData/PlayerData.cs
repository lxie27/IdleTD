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

        TowerModel SUPERSPEEDBASIC = TowerModel.ModelFactory.CreateTowerModel(TowerType.Basic);
        GemData gem1 = new GemData();
        gem1.rarity = Rarity.Mythical;
        SUPERSPEEDBASIC.attackSpeed += 20f;
        SUPERSPEEDBASIC.damage = .01f;
        save.towerInventory.Add(SUPERSPEEDBASIC);
        SUPERSPEEDBASIC.gemsData.Add(gem1);

        TowerModel SUPERRANGEBASIC = TowerModel.ModelFactory.CreateTowerModel(TowerType.Basic);
        GemData gem2 = new GemData();
        gem1.rarity = Rarity.Mythical;
        SUPERSPEEDBASIC.radius = 10f;
        save.towerInventory.Add(SUPERRANGEBASIC);
        SUPERRANGEBASIC.gemsData.Add(gem2);

        TowerModel t3 = TowerModel.ModelFactory.CreateTowerModel(TowerType.Ranged);
        save.towerInventory.Add(t3);

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
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

    public static PlayerData CreateDevSaveData()
    {
        PlayerData save = new PlayerData();

        TowerData td1 = new TowerData();
        td1.damage = 10f;
        td1.attackSpeed = 5f;
        td1.radius = 20f;

        save.towerInventory.Add(td1);

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
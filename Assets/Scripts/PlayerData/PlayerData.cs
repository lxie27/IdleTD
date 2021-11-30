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

        Modifier ad10 = ModifierFactory.CreateModifier(GemModifierTypes.AttackDamage, 10f);
        GemData ad10Gem = new GemData(ad10);
        save.gemInventory.Add(ad10Gem);

        TowerModel t1 = TowerModel.ModelFactory.CreateTowerModelFromType(TowerType.Basic);
        t1.attackSpeed = 1f;
        t1.damage = 2f;
        t1.name = "Basic tower w/ 10ADgem";

        t1.AddGem(save.gemInventory[0]);
        TowerModel.ModelFactory.ApplyStarBonus(t1);

        TowerModel t2 = TowerModel.ModelFactory.CreateTowerModelFromType(TowerType.Basic);
        t2.name = "Basic tower 2";
        t2.stars = 0;

        TowerModel t3 = TowerModel.ModelFactory.CreateTowerModelFromType(TowerType.Ranged);
        t3.name = "Normal Range Tower";

        save.towerInventory.Add(t1);
        save.towerInventory.Add(t2);
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
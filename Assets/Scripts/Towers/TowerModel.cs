using System.Collections;
using System.Collections.Generic;
using System;
public interface ITowerModel
{

}

[System.Serializable]
public class TowerModel : ITowerModel
{
    public List<GemData> gemsData;
    public TowerType type;

    public float damage;
    public float radius;
    public float attackSpeed;

    private TowerModel()
    {
        //default values
        damage = 1f;
        radius = 5f;
        attackSpeed = 1f;
        type = TowerType.Basic;
        gemsData = new List<GemData>();
    }

    public class Factory
    {
        public static TowerModel CreateTowerModel()
        {
            return new TowerModel();
        }
    }
}
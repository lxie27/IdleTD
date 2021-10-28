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
        damage              = 1f;
        radius              = 5f;
        attackSpeed         = 1f;
        type                = TowerType.Basic;
        gemsData            = new List<GemData>();
    }

    public void CopyModelData(TowerModel _model)
    {
        this.damage         = _model.damage;
        this.radius         = _model.radius;
        this.attackSpeed    = _model.attackSpeed;
        this.type           = _model.type;
        this.gemsData       = _model.gemsData;
    }

    public static void SetBasicTowerDefaults(TowerModel _model)
    {
        _model.damage = 2f;
        _model.radius = 5f;
        _model.attackSpeed = 1f;
        _model.type = TowerType.Basic;
        _model.gemsData = new List<GemData>();
    }

    public static void SetRangedTowerDefaults(TowerModel _model)
    {
        _model.damage = 2f;
        _model.radius = 10f;
        _model.attackSpeed = .5f;
        _model.type = TowerType.Ranged;
        _model.gemsData = new List<GemData>();
    }

    public class ModelFactory
    {
        public static TowerModel CreateTowerModel()
        {
            return new TowerModel();
        }

        public static TowerModel CreateTowerModel(TowerType type)
        {
            TowerModel model = new TowerModel();
            switch (type)
            {
                case TowerType.Basic:
                    SetBasicTowerDefaults(model);
                    break;

                case TowerType.Ranged:
                    SetRangedTowerDefaults(model);
                    break;

                default:
                    break;
            }

            return model;
        }
    }
}
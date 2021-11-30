using System.Collections;
using System.Collections.Generic;
using System;
public interface ITowerModel
{

}

[System.Serializable]
public class TowerModel : ITowerModel
{
    const float STARBONUS = .1f; // each star adds 10% to damage/AS
    public string name;
    public List<GemData> gemsData;
    public TowerType type;

    public float damage;
    public float radius;
    //1f is 1 second, for faster attack speed decrease this value
    public float attackSpeed;
    public int stars;
    private TowerModel()
    {
        //default values
        damage              = 1f;
        radius              = 5f;
        attackSpeed         = 1f;
        type                = TowerType.Basic;
        name                = type + "";
        gemsData            = new List<GemData>();
        stars               = 0;
    }

    // Tower's responsibility to call to apply modifier
    public void AddGem(GemData gemData)
    {
        this.gemsData.Add(gemData);
        gemData.ApplyModifiers(this);
    }

    public void CopyModelData(TowerModel _model)
    {
        this.damage         = _model.damage;
        this.radius         = _model.radius;
        this.attackSpeed    = _model.attackSpeed;
        this.type           = _model.type;
        this.name           = _model.name;
        this.gemsData       = _model.gemsData;
        this.stars          = _model.stars;
    }

    public static void SetBasicTowerDefaults(TowerModel _model)
    {
        _model.damage       = 2f;
        _model.radius       = 5f;
        _model.attackSpeed  = 1f;
        _model.type         = TowerType.Basic;
        _model.name         = TowerType.Basic + "";
        _model.gemsData     = new List<GemData>();
        _model.stars        = 0;
    }

    public static void SetRangedTowerDefaults(TowerModel _model)
    {
        _model.damage       = 2f;
        _model.radius       = 10f;
        _model.attackSpeed  = 1.5f;
        _model.type         = TowerType.Ranged;
        _model.name         = TowerType.Ranged + "";
        _model.gemsData     = new List<GemData>();
        _model.stars        = 0;
    }

    public class ModelFactory
    {
        public static TowerModel CreateTowerModel()
        {
            return new TowerModel();
        }

        public static TowerModel CreateTowerModelFromType(TowerType type)
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
        public static void ApplyStarBonus(TowerModel _model)
        {
            _model.damage += _model.damage * (_model.stars * STARBONUS);
            _model.attackSpeed = _model.attackSpeed - (_model.stars * STARBONUS);
        }
    }
}
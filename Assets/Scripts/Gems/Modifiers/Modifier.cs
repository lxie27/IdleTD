using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Modifier
{
    GemModifierTypes modifier;

    public Modifier(GemModifierTypes _modifier)
    {
        modifier = _modifier;
    }

    public virtual void ApplyModifier(TowerModel _model)
    {

    }
}

[System.Serializable]
public static class ModifierFactory
{
    public static Modifier CreateModifier(GemModifierTypes _gemModifier, float _value)
    {
        switch (_gemModifier)
        {
            case GemModifierTypes.AttackSpeed:
                return new AttackSpeed(_gemModifier, _value);
            case GemModifierTypes.AttackDamage:
                return new AttackDamage(_gemModifier, _value);
            case GemModifierTypes.RangeIncrease:
                return new RangeIncrease(_gemModifier, _value);
            default:
                return null;
        }
    }
}

[System.Serializable]
class AttackSpeed : Modifier
{
    float attackSpeedIncrease;

    public AttackSpeed(GemModifierTypes _modifier, float _attackSpeedIncrease) : base(_modifier)
    {
        attackSpeedIncrease = _attackSpeedIncrease;
    }

    public override void ApplyModifier(TowerModel tower)
    {
        tower.attackSpeed *= attackSpeedIncrease;
    }
}

[System.Serializable]
class AttackDamage : Modifier
{
    float attackDamageIncrease;

    public AttackDamage(GemModifierTypes _modifier, float _attackDamageIncrease) : base(_modifier)
    {
        attackDamageIncrease = _attackDamageIncrease;
    }

    public override void ApplyModifier(TowerModel tower)
    {
        tower.damage += attackDamageIncrease;
    }
}

[System.Serializable]
class RangeIncrease : Modifier
{
    float rangeIncrease;

    public RangeIncrease(GemModifierTypes _modifier, float _rangeIncrease) : base(_modifier)
    {
        rangeIncrease = _rangeIncrease;
    }

    public override void ApplyModifier(TowerModel tower)
    {
        tower.damage += rangeIncrease;
    }
}
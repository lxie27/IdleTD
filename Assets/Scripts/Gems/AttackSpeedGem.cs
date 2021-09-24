using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedGem : Gem
{
    public float attackSpeedIncrease;

    public AttackSpeedGem(float attackSpeedIncrease)
    {
        this.attackSpeedIncrease = attackSpeedIncrease;
    }

    override public void ApplyModifiers(Tower tower)
    {
        if (!isApplied)
        {
            tower.attackSpeed *= attackSpeedIncrease;
            isApplied = true;
        }
    }
}
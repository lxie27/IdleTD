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

    override public void ApplyModifier(Tower tower)
    {
        if (!this.gemData.isApplied)
        {
            tower.towerData.attackSpeed *= attackSpeedIncrease;
            this.gemData.isApplied = true;
        }
    }
}
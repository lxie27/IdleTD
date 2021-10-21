using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatDamageGem : Gem
{
    public float attackIncrease;

    public FlatDamageGem(float attackIncrease)
    {
        this.attackIncrease = attackIncrease;
    }

    override public void ApplyModifier(Tower tower)
    {
        if (!this.gemData.isApplied)
        {
            tower.towerData.damage += attackIncrease;
            this.gemData.isApplied = true;
        }
    }
}
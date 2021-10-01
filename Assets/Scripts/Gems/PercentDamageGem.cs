using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentDamageGem : Gem
{
    public float attackIncrease;

    public PercentDamageGem(float attackIncrease)
    {
        this.attackIncrease = attackIncrease;
    }

    override public void ApplyModifier(Tower tower)
    {
        if (!this.gemData.isApplied)
        {
            tower.damage *= attackIncrease;
            this.gemData.isApplied = true;
        }
    }
}

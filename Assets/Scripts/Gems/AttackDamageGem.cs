using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageGem : Gem
{
    public float attackIncrease;

    public AttackDamageGem(float attackIncrease)
    {
        this.attackIncrease = attackIncrease;
    }

    override public void ApplyModifiers(Tower tower)
    {
        if (!isApplied)
        {
            tower.damage *= attackIncrease;
            isApplied = true;
        }
    }
}
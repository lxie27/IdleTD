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

    override public void ApplyModifiers(Tower tower)
    {
        if (!isApplied)
        {
            tower.damage += attackIncrease;
            isApplied = true;
        }
    }
}
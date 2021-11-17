using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GemData
{
    public Rarity rarity;
    public List<Modifier> modifiers = new List<Modifier>();

    public GemData()
    {
        this.rarity = Rarity.Common;
    }

    public GemData(Modifier _modifier)
    {
        this.rarity = Rarity.Common;
        modifiers.Add(_modifier);
    }

    public GemData(List<Modifier> _modifiers)
    {
        this.rarity = Rarity.Common;
        modifiers = _modifiers;
    }
    public void AddModifier(Modifier _mod)
    {
        modifiers.Add(_mod);
    }

    public void ApplyModifiers(TowerModel _tower)
    {
        foreach(var mod in modifiers)
        {
            mod.ApplyModifier(_tower);
        }
    }
    public void RerollLines()
    {
        foreach (var mod in modifiers)
        {
            Debug.Log("Rerolling " + mod);
        }
    }
    public void UpgradeRarity(Rarity upgrade)
    {
        if (upgrade > rarity)
        {
            rarity = upgrade;
        }
        else
        {
            Debug.Log("Passed in rarity upgrade lower than current rarity");
        }
    }
}
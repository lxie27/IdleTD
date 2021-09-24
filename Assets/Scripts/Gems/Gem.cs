using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem
{
    public Rarity rarity;
    public bool isApplied = false;
    int numberOfLines;
    List<GemModifiers> modifiers;

    public Gem()
    {

    }

    virtual public void RerollLines()
    {
        return;
    }

    virtual public void ApplyModifiers(Tower tower)
    {

    }

    virtual public Rarity UpgradeRarity(Rarity upgrade)
    {
        this.rarity = upgrade;
        return upgrade;
    }
}
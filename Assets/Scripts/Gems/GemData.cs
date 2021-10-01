using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GemData
{
    public Rarity rarity;
    public bool isApplied = false;
    public List<GemModifier> modifiers;

    public GemData()
    {
        this.rarity = Rarity.None;
    }
}
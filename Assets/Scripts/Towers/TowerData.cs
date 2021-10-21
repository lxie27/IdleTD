using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData
{
    public float damage;
    public float radius;
    public float attackSpeed;
    public List<GemData> gemsData;
    public TowerType type;
}
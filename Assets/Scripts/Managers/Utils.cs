using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class Utils
{
    public static Sprite GetIconFromTowerModel(TowerModel _model)
    {
        switch(_model.type)
        {
            case TowerType.Basic:
                return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Towers/BaseTower/BasicTowerHead.png");
            default:
                return null;
        }
    }
}

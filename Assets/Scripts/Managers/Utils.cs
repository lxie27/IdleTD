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
            case TowerType.Ranged:
                return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Towers/BaseTower/RangedTowerHead.png");
            default:
                return null;
        }
    }
    
    //Sets gameobject and all its children's layers to layerNumber
    public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}

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
                return Resources.Load<Sprite>("Sprites/Towers/BasicTowerHead");
            case TowerType.Ranged:
                return Resources.Load<Sprite>("Sprites/Towers/RangedTowerHead");
            default:
                return null;
        }
    }
    public static Sprite GetIconFromGemData(GemData _gemData)
    {
        switch (_gemData.rarity)
        {
            case Rarity.Common:
                return Resources.Load<Sprite>("Sprites/Gems/BaseCommonGem");

            case Rarity.Rare:
                return Resources.Load<Sprite>("Sprites/Gems/BaseRareGem");

            case Rarity.Epic:
                return Resources.Load<Sprite>("Sprites/Gems/BaseEpicGem");

            case Rarity.Legendary:
                return Resources.Load<Sprite>("Sprites/Gems/BaseLegendaryGem");

            case Rarity.Mythical:
                return Resources.Load<Sprite>("Sprites/Gems/BaseMythicalGem");

            default:
                Debug.Log("This gem's rarity was never assigned");
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

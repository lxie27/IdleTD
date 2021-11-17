using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GemFactory
{
    static GameObject baseGemPrefab = Resources.Load<GameObject>("Prefabs/Gems/BaseGem");
    static GemFactory()
    {

    }

    /// <summary>
    /// Creates an Attack Damage Gem
    /// </summary>
    /// <param name="damageIncrease">   - amount of damage the gem gives    </param>
    /// <returns name="adGemObject">    - the attack damage gem             </returns>
    /*public static GameObject CreateAttackDamageGem(float damageIncrease)
    {

    }

    /// <summary>
    /// Creates an Attack Speed Gem
    /// </summary>
    /// <param name="speedIncrease">    - amount of attack speed the gem gives  </param>
    /// <returns name="asGemObject">    - the attack speed gem                  </returns>
    public static GameObject CreateAttackSpeedGem(float speedIncrease)
    {
        GameObject asGemObject = new GameObject();
        asGemObject.AddComponent<AttackSpeedGem>();

        AttackSpeedGem asGem = asGemObject.GetComponent<AttackSpeedGem>();\

        return asGemObject;
    }*/

    /// <summary>
    /// General factory for gem objects from GemData
    /// </summary>
    /// <param name="_gemData">          - gem data to generate gem object from </param>
    /// <returns name="go">             - the gem game object                  </returns>
    public static GameObject CreateGemObject(GemData _gemData)
    {
        GameObject go = new GameObject();
        go.AddComponent<Gem>();
        Gem goGem = go.GetComponent<Gem>();
        goGem.gemData = _gemData;
        goGem.sprite = SetSprite(goGem.gemData.rarity);
        return go;
    }

    public static Sprite SetSprite(Rarity rarity)
    {
        Sprite sprite;
        switch (rarity)
        {
            case Rarity.Common:
                sprite = Resources.Load<Sprite>("Sprites / Gems / BaseCommonGem.png");
                break;

            case Rarity.Rare:
                sprite = Resources.Load<Sprite>("Sprites / Gems / BaseRareGem.png");
                break;

            case Rarity.Epic:
                sprite = Resources.Load<Sprite>("Sprites / Gems / BaseEpicGem.png");
                break;

            case Rarity.Legendary:
                sprite = Resources.Load<Sprite>("Sprites / Gems / BaseLegendaryGem.png");
                break;

            case Rarity.Mythical:
                sprite = Resources.Load<Sprite>("Sprites / Gems / BaseMythicalGem.png");
                break;

            default:
                Debug.Log("This gem's rarity was never assigned");
                sprite = Resources.Load<Sprite>("Sprites / Gems / BaseCommonGem.png");
                break;
        }
        return sprite;
    }
    public static Color SetSpriteColor(Rarity rarity)
    {
        Color color;
        switch (rarity)
        {
            case Rarity.Common:
                color = Color.white;
                break;

            case Rarity.Rare:
                color = Color.green;
                break;

            case Rarity.Epic:
                color = Color.blue;
                break;

            case Rarity.Legendary:
                color = new Color(1f, .64f, 0);
                break;

            case Rarity.Mythical:
                color = new Color(.5f, 0, .5f);
                break;

            default:
                Debug.Log("This gem's rarity was never assigned");
                color = Color.gray;
                break;
        }

        return color;
    }

}
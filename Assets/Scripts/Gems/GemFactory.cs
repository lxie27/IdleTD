using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GemFactory
{
    static GameObject baseGem;

    // All projectiles should be loaded in here
    static GemFactory()
    {
        baseGem = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Gems/BaseCommon", typeof(GameObject));
    }

    /// <summary>
    /// Creates an Attack Damage Gem at spawner's location that is given the target
    /// </summary>
    /// <param name="damageIncrease">   - amount of damage the gem gives    </param>
    /// <returns name="go">             - the attack damage gem             </returns>
    public static Gem CreateAttackDamageGem(float damageIncrease)
    {
        FlatDamageGem gem = new FlatDamageGem(damageIncrease);
        return gem;
    }

    /// <summary>
    /// Creates an Attack Speed Gem at spawner's location that is given the target
    /// </summary>
    /// <param name="speedIncrease">    - amount of attack speed the gem gives  </param>
    /// <returns name="go">             - the attack speed gem                  </returns>
    public static Gem CreateAttackSpeedGem(float speedIncrease)
    {
        AttackSpeedGem gem = new AttackSpeedGem(speedIncrease);
        return gem;
    }

    /// <summary>
    /// Creates an Attack Speed Gem at spawner's location that is given the target
    /// </summary>
    /// <param name="speedIncrease">    - amount of attack speed the gem gives  </param>
    /// <returns name="go">             - the attack speed gem                  </returns>
    public static Gem CreateGemFromData(float speedIncrease)
    {
        AttackSpeedGem gem = new AttackSpeedGem(speedIncrease);
        return gem;
    }

}
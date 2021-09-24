using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemFactory : MonoBehaviour
{
    static GameObject baseGem;

    // All projectiles should be loaded in here
    static GemFactory()
    {
        baseGem = Resources.Load("Projectiles/Base_Projectile", typeof(GameObject)) as GameObject;
    }

    /// <summary>
    /// Creates an Attack Damage Gem at spawner's location that is given the target
    /// </summary>
    /// <param name="damageIncrease">   - amount of damage the gem gives    </param>
    /// <returns name="go">             - the attack damage gem             </returns>
    public static Gem CreateAttackDamageGem(float damageIncrease)
    {
        AttackDamageGem gem = new AttackDamageGem(damageIncrease);
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

}
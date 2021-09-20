using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectileFactory
{
    static GameObject baseProjectile;

    // All projectiles should be loaded in here
    static ProjectileFactory()
    {
        baseProjectile = Resources.Load("Projectiles/Base_Projectile", typeof(GameObject)) as GameObject;
    }

    // TODO just uses base projectile instead of getting a parameter to check tower type to determine projectile
    /// <summary>
    /// Creates a object proj at spawner's location that is given the target
    /// </summary>
    /// <param name="spawner">  - transform of the spawner object   </param>
    /// <param name="proj">     - prefab of a projectile            </param>
    /// <param name="target">   - transform of the targeted object  </param>
    /// <returns name="go">     - pointer to the spawned projectile </returns>
    public static GameObject Spawn(GameObject proj, Transform spawner, Transform target)
    {
        GameObject go = GameObject.Instantiate(baseProjectile, spawner, true);
        if (go.TryGetComponent<BaseProjectile>(out var bp))
        {
            bp.target = target.gameObject;
        }

        return go;
    }
}

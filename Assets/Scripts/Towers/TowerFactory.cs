using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory
{
    static GameObject baseTower;

    // All projectiles should be loaded in here
    static TowerFactory()
    {
        baseTower = Resources.Load("Towers/Base_Tower", typeof(GameObject)) as GameObject;
    }

    /// <summary>
    /// Creates a tower prefab at given
    /// </summary>
    /// <param name="tower">    - prefab of the tower               </param>
    /// <param name="position"> - position of the targeted object   </param>
    /// <returns name="go">     - pointer to the spawned projectile </returns>
    public static GameObject Spawn(GameObject tower, Vector2Int position)
    {
        return GameObject.Instantiate(baseTower, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }
}

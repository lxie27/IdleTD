using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TowerFactory
{
    static GameObject baseTower;

    // All projectiles should be loaded in here
    static TowerFactory()
    {
        baseTower = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Towers/BaseTower.prefab", typeof(GameObject));

        if (baseTower == null)
        {
            Debug.Log("failed to load tower");
        }
    }

    /// <summary>
    /// Creates a tower prefab at given
    /// </summary>
    /// <param name="position"> - position of the targeted object   </param>
    /// <returns name="go">     - pointer to the spawned projectile </returns>
    public static GameObject Spawn(Vector2Int position)
    {
        return GameObject.Instantiate(baseTower, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }

    /// <summary>
    /// Creates a tower prefab at given
    /// </summary>
    /// <param name="position"> - position of the targeted object   </param>
    /// <returns name="go">     - pointer to the spawned projectile </returns>
    public static GameObject Spawn(Vector2 position)
    {
        return GameObject.Instantiate(baseTower, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }
}

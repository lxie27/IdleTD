using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class TowerFactory
{
    static GameObject baseTower;
    static GameObject rangedTower;

    static TowerFactory()
    {
        baseTower       = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Towers/Tower_Basic.prefab", typeof(GameObject));
        rangedTower     = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Towers/Tower_Ranged.prefab", typeof(GameObject));
    }

    /// <summary>
    /// Creates a tower object  at given position
    /// </summary>
    /// <param name="_model">   - model of the Tower to spawn         </param>
    /// <param name="position"> - position of the targeted object   </param>
    /// <returns name="go">     - pointer to the spawned tower      </returns>
    public static GameObject Spawn(Vector2 position, TowerModel _model)
    {
        GameObject tower;

        //  Set the tower's image
        switch (_model.type)
        {
            case TowerType.Basic:
                tower =  GameObject.Instantiate(baseTower, new Vector3(position.x, position.y, 0), Quaternion.identity);
                break;
            case TowerType.Ranged:
                tower = GameObject.Instantiate(rangedTower, new Vector3(position.x, position.y, 0), Quaternion.identity);
                break;
            default:
                tower = GameObject.Instantiate(baseTower, new Vector3(position.x, position.y, 0), Quaternion.identity);
                break;
        }

        tower.GetComponent<TowerView>().model = _model;

        return tower;
    }

    /// <summary>
    /// Extracts the tower's sprite from a model
    /// </summary>
    /// <param name="_model"> - model of the Tower to get a sprite of </param>
    /// <returns name="towerSprite">     - pointer to the spawned projectile </returns>
    public static Sprite GetTowerSprite(TowerModel _model)
    {
        Sprite towerSprite;
        GameObject tempTower;

        switch (_model.type)
        {
            case TowerType.Basic:
                tempTower = GameObject.Instantiate(baseTower);
                break;
            case TowerType.Ranged:
                tempTower = GameObject.Instantiate(rangedTower);
                break;
            default:
                tempTower = GameObject.Instantiate(baseTower);
                break;
        }

        towerSprite = tempTower.GetComponent<SpriteRenderer>().sprite;
        GameObject.Destroy(tempTower);
        return towerSprite;
    }
}

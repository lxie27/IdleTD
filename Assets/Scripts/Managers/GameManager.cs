using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static PlayerData playerData = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        //Load save
        playerData = PlayerData.CreateDevSaveData();
        SaveLoad.Save(playerData);
        SaveLoad.Load();
        LoadPlayerData();
        Debug.Log("Towers in player save data: " + playerData.towerInventory.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadPlayerData()
    {

    }
}

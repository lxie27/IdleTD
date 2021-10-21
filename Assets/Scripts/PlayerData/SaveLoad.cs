using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static PlayerData currentPlayer = new PlayerData();

    public static void Save()
    {
        currentPlayer = currentPlayer.CreateSaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/DEBUGsavegame.itds");
        bf.Serialize(file, SaveLoad.currentPlayer);
        file.Close();
        Debug.Log("Game saved");
    }

    public static void Save(PlayerData save)
    {
        currentPlayer = save;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/DEBUGsavegame.itds");
        bf.Serialize(file, SaveLoad.currentPlayer);
        file.Close();
        Debug.Log("Game saved");
    }

    public static int Load()
    {
        if (File.Exists(Application.persistentDataPath + "/DEBUGsavegame.itds"))
        {
            Debug.Log("Found save file at : " + Application.persistentDataPath + "/DEBUGsavegame.itds");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/DEBUGsavegame.itds", FileMode.Open);
            SaveLoad.currentPlayer = (PlayerData)bf.Deserialize(file);
            file.Close();
            return 0;
        }
        else
        {
            Debug.Log("Did not find any save files, creating a new profile.");
            Save();
            return -1;
        }
    }
}
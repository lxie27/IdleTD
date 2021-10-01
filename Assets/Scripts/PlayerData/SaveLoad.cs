using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static PlayerData savedGame = new PlayerData();

    public static void Save()
    {
        savedGame = savedGame.CreateSaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/DEBUGsavegame.itds");
        bf.Serialize(file, SaveLoad.savedGame);
        file.Close();

        Debug.Log("Game saved");
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/DEBUGsavegame.itds"))
        {
            Debug.Log("Found save file at : " + Application.persistentDataPath + "/DEBUGsavegame.itds");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/DEBUGsavegame.itds", FileMode.Open);
            SaveLoad.savedGame = (PlayerData)bf.Deserialize(file);
            file.Close();
        }
    }
}
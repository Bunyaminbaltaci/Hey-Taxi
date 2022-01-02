 
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public float Volume;
    public bool mute;
    public int currentCostume;
    public float money;
    public bool[] CostumeUnlocked = new bool[5] { false,false,false,false,true};


    private void Awake()
    {
        if (instance!=null && instance!=this)
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        Load();
    }
  
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath +"/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +"/playerInfo.dat",FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);
            Volume = data.Volume;
            mute = data.mute;
            money = data.money;
            currentCostume = data.currentcostume;
            CostumeUnlocked = data.CostumeUnlocked;
            if (data.CostumeUnlocked==null)
            {
                CostumeUnlocked = new bool[5] { false, false, false, false, true };
            }
            file.Close();
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath +"/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();
        data.mute = mute;
        data.Volume = Volume;
        data.money = money;
        data.currentcostume = currentCostume;
        data.CostumeUnlocked =CostumeUnlocked;


        bf.Serialize(file, data);
        file.Close();

    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentcostume;
    public float money;
    public bool[] CostumeUnlocked;
    public float Volume;
    public bool mute;
}

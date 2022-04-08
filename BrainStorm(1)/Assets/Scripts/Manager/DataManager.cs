using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataInfo;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataManager";
                _instance = _container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    private void Start()
    {
        LoadData();
        //SaveData();
    }

    private string dataPath;

    public void Initialize()
    {
        dataPath = Application.dataPath + "/gameData.dat";
    }

    public void SaveData(GameData gameData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(dataPath);

        GameData data = new GameData();

        data.ScoreSetting = gameData.ScoreSetting;
        data.BGMSetting = gameData.BGMSetting;
        data.SESetting = gameData.SESetting;
        data.TimerSetting = gameData.TimerSetting;
        data.StarSetting = gameData.StarSetting;

        data.savePoint = gameData.savePoint;

        data.star = gameData.star;
        data.bigStar = gameData.bigStar;

        data.WorldScore = gameData.WorldScore;
        data.WorldAchive = gameData.WorldAchive;
        data.WorldStar = gameData.WorldStar;
        data.WorldBigStar = gameData.WorldBigStar;
        data.WorldTime = gameData.WorldTime;
        data.WorldLife = gameData.WorldLife;

        bf.Serialize(file, data);
        file.Close();
    }

    public GameData LoadData()
    {
        if(File.Exists(dataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);

            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            GameData data = new GameData();

            return data;
        }
    }
}

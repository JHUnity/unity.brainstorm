using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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

    /*
    private void Awake()
    {
        var objs = FindObjectsOfType<DataManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    */

    public string GameDataFileName = ".json";

    public UserManager _gameData;
    public UserManager gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    private void Start()
    {
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.streamingAssetsPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            Debug.Log("데이터를 불러왔습니다.");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<UserManager>(FromJsonData);
        }
        else
        {
            Debug.Log("데이터를 새로 생성합니다.");
            _gameData = new UserManager();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.streamingAssetsPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("데이터를 저장했습니다.");
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}

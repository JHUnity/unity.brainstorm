using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
/*
[Serializable]
public class ScoreData
{
    public float[] StageScore = new float[10];
}
[Serializable]
public class AchiveData
{
    public float[] StageAchive = new float[10];
}
[Serializable]
public class StarData
{
    public int[] StageStar = new int[10];
}
[Serializable]
public class BigStarData
{
    public bool[] StageBigStar = new bool[10];
}
[Serializable]
public class TimeData
{
    public float[] StageTime = new float[10];
}
[Serializable]
public class LifeData
{
    public int[] StageLife = new int[10];
}
[Serializable]
public class NormalUnlockData
{
    public bool[] StageNormalUnlock = new bool[10];
}
[Serializable]
public class SpecialUnlockData
{
    public bool[] StageSpecialUnlock = new bool[10];
}
*/

//[Serializable]
public class UserManager : MonoBehaviour
{
    public bool ScoreSetting;
    public float BGMSetting;
    public float SESetting;
    public bool ItemSetting;
    public bool TimerSetting;
    public bool StarSetting;

    public int star;
    public int bigStar;

    public float[,] WorldScore = new float[100, 100];
    public float[,] WorldAchive = new float[100, 100];
    public int[,] WorldStar = new int[100, 100];
    public bool[,] WorldBigStar = new bool[100, 100];
    public float[,] WorldTime = new float[100, 100];
    public int[,] WorldLife = new int[100, 100];
    public bool[,] WorldNormalUnlock = new bool[100, 100];

    public bool loadOn;

    public void SavePlayer()
    {
        GameData save = new GameData();

        save.ScoreSetting = ScoreSetting;
        save.BGMSetting = BGMSetting;
        save.SESetting = SESetting;
        save.ItemSetting = ItemSetting;
        save.TimerSetting = TimerSetting;
        save.StarSetting = StarSetting;

        save.star = star;
        save.bigStar = bigStar;

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldScore[i, j] = WorldScore[i, j];
            }
        }

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldAchive[i, j] = WorldAchive[i, j];
            }
        }

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldStar[i, j] = WorldStar[i, j];
            }
        }

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldBigStar[i, j] = WorldBigStar[i, j];
            }
        }

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldTime[i, j] = WorldTime[i, j];
            }
        }

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldLife[i, j] = WorldLife[i, j];
            }
        }

        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                save.WorldNormalUnlock[i, j] = WorldNormalUnlock[i, j];
            }
        }

        DataManager.Save(save);
    }

    public void LoadPlayer()
    {
        loadOn = true;
        GameData save = DataManager.Load();
        if (loadOn == true)
        {
            ScoreSetting = save.ScoreSetting;
            BGMSetting = save.BGMSetting;
            SESetting = save.SESetting;
            ItemSetting = save.ItemSetting;
            TimerSetting = save.TimerSetting;
            StarSetting = save.StarSetting;

            SettingManager.Instance.ScoreSet2();
            SettingManager.Instance.ItemSet2();
            SettingManager.Instance.TimerSet2();
            SettingManager.Instance.StarSet2();

            star = save.star;
            bigStar = save.bigStar;

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldScore[i, j] = save.WorldScore[i, j];
                }
            }

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldAchive[i, j] = save.WorldAchive[i, j];
                }
            }

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldStar[i, j] = save.WorldStar[i, j];
                }
            }

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldBigStar[i, j] = save.WorldBigStar[i, j];
                }
            }

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldTime[i, j] = save.WorldTime[i, j];
                }
            }

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldLife[i, j] = save.WorldLife[i, j];
                }
            }

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    WorldNormalUnlock[i, j] = save.WorldNormalUnlock[i, j];
                }
            }
        }

    }

    private static UserManager instance;
    public static UserManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<UserManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<UserManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<UserManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ScoreSetting = false;
        ItemSetting = true;
        TimerSetting = true;
        StarSetting = true;

        LoadPlayer();
        SavePlayer();
    }
}

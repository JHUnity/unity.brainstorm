using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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

    public ScoreData[] WorldScore = new ScoreData[10];
    public AchiveData[] WorldAchive = new AchiveData[10];
    public StarData[] WorldStar = new StarData[10];
    public BigStarData[] WorldBigStar = new BigStarData[10];
    public TimeData[] WorldTime = new TimeData[10];
    public LifeData[] WorldLife = new LifeData[10];

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

        for (int i = 1; i < WorldScore.Length; i++)
        {
            for (int j = 1; j < WorldScore[i].StageScore.Length; j++)
            {
                save.WorldScore[i,j] = WorldScore[i].StageScore[j];
            }
        }
        
        for (int i = 1; i < WorldAchive.Length; i++)
        {
            for (int j = 1; j < WorldAchive[i].StageAchive.Length; j++)
            {
                save.WorldAchive[i,j] = WorldAchive[i].StageAchive[j];
            }
        }

        for (int i = 1; i < WorldStar.Length; i++)
        {
            for (int j = 1; j < WorldStar[i].StageStar.Length; j++)
            {
                save.WorldStar[i,j] = WorldStar[i].StageStar[j];
            }
        }

        for (int i = 1; i < WorldBigStar.Length; i++)
        {
            for (int j = 1; j < WorldBigStar[i].StageBigStar.Length; j++)
            {
                save.WorldBigStar[i,j] = WorldBigStar[i].StageBigStar[j];
            }
        }

        for (int i = 1; i < WorldTime.Length; i++)
        {
            for (int j = 1; j < WorldTime[i].StageTime.Length; j++)
            {
                save.WorldTime[i,j] = WorldTime[i].StageTime[j];
            }
        }

        for (int i = 1; i < WorldLife.Length; i++)
        {
            for (int j = 1; j < WorldLife[i].StageLife.Length; j++)
            {
                save.WorldLife[i,j] = WorldLife[i].StageLife[j];
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

            for (int i = 1; i < WorldScore.Length; i++)
            {
                for (int j = 1; j < WorldScore[i].StageScore.Length; j++)
                {
                    WorldScore[i].StageScore[j] = save.WorldScore[i, j];
                }
            }

            for (int i = 1; i < WorldAchive.Length; i++)
            {
                for (int j = 1; j < WorldAchive[i].StageAchive.Length; j++)
                {
                     WorldAchive[i].StageAchive[j] = save.WorldAchive[i, j];
                }
            }

            for (int i = 1; i < WorldStar.Length; i++)
            {
                for (int j = 1; j < WorldStar[i].StageStar.Length; j++)
                {
                    WorldStar[i].StageStar[j] = save.WorldStar[i, j];
                }
            }

            for (int i = 1; i < WorldBigStar.Length; i++)
            {
                for (int j = 1; j < WorldBigStar[i].StageBigStar.Length; j++)
                {
                    WorldBigStar[i].StageBigStar[j] = save.WorldBigStar[i, j];
                }
            }

            for (int i = 1; i < WorldTime.Length; i++)
            {
                for (int j = 1; j < WorldTime[i].StageTime.Length; j++)
                {
                    WorldTime[i].StageTime[j] = save.WorldTime[i, j];
                }
            }

            for (int i = 1; i < WorldLife.Length; i++)
            {
                for (int j = 1; j < WorldLife[i].StageLife.Length; j++)
                {
                     WorldLife[i].StageLife[j] = save.WorldLife[i, j];
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

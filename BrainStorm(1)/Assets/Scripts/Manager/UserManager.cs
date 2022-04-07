﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreData
{
    public float[] StageScore;
}
[System.Serializable]
public class AchiveData
{
    public float[] StageAchive;
}
[System.Serializable]
public class StarData
{
    public int[] StageStar;
}
[System.Serializable]
public class BigStarData
{
    public bool[] StageBigStar;
}
[System.Serializable]
public class TimeData
{
    public float[] StageTime;
}
[System.Serializable]
public class LifeData
{
    public int[] StageLife;
}

public class UserManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public Text starText;
    public Text bigStarText;

    public ScoreData[] WorldScore;
    public AchiveData[] WorldAchive;
    public StarData[] WorldStar;
    public BigStarData[] WorldBigStar;
    public TimeData[] WorldTime;
    public LifeData[] WorldLife;

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

    void Update()
    {
        starText.text = "x" + star.ToString();
        bigStarText.text = "x" + bigStar.ToString();
    }
}

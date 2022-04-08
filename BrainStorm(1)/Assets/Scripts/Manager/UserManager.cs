using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ScoreData
{
    public float[] StageScore;
}
[Serializable]
public class AchiveData
{
    public float[] StageAchive;
}
[Serializable]
public class StarData
{
    public int[] StageStar;
}
[Serializable]
public class BigStarData
{
    public bool[] StageBigStar;
}
[Serializable]
public class TimeData
{
    public float[] StageTime;
}
[Serializable]
public class LifeData
{
    public int[] StageLife;
}

[Serializable]
public class UserManager : MonoBehaviour
{
    public int star;
    public int bigStar;

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

}

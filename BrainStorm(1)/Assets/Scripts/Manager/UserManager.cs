using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float[] StageStar;
}
[System.Serializable]
public class TimeData
{
    public float[] StageTime;
}
[System.Serializable]
public class LifeData
{
    public float[] StageLife;
}

public class UserManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public ScoreData[] WorldScore;
    public AchiveData[] WorldAchive;
    public StarData[] WorldStar;
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

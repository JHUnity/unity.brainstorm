using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{
    public bool ScoreSetting;
    public float BGMSetting;
    public float SESetting;
    public bool ItemSetting;
    public bool TimerSetting;
    public bool StarSetting;

    public int star;
    public int bigStar;

    public float[,] WorldScore = new float[10, 10];
    public float[,] WorldAchive = new float[10, 10];
    public int[,] WorldStar = new int[10, 10];
    public bool[,] WorldBigStar = new bool[10, 10];
    public float[,] WorldTime = new float[10, 10];
    public int[,] WorldLife = new int[10, 10];
}


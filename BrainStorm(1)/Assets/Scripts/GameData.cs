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

    public float[,] WorldScore = new float[100, 100];
    public float[,] WorldAchive = new float[100, 100];
    public int[,] WorldStar = new int[100, 100];
    public bool[,] WorldBigStar = new bool[100, 100];
    public float[,] WorldTime = new float[100, 100];
    public int[,] WorldLife = new int[100, 100];
    public bool[,] WorldNormalUnlock = new bool[100, 100];
    public bool[] WorldUnlock = new bool[100];
}


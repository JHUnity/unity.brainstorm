using System.Collections.Generic;

[System.Serializable]
public class PlayerScoreData
{
    public float[] StageScore;
}
[System.Serializable]
public class PlayerAchiveData
{
    public float[] StageAchive;
}
[System.Serializable]
public class PlayerStarData
{
    public int[] StageStar;
}
[System.Serializable]
public class PlayerBigStarData
{
    public bool[] StageBigStar;
}
[System.Serializable]
public class PlayerTimeData
{
    public float[] StageTime;
}
[System.Serializable]
public class PlayerLifeData
{
    public int[] StageLife;
}

namespace DataInfo
{
    [System.Serializable]
    public class GameData
    {
        public bool ScoreSetting;
        public float BGMSetting;
        public float SESetting;
        public bool TimerSetting;
        public bool StarSetting;

        public int savePoint;

        public int star;
        public int bigStar;

        public PlayerScoreData[] WorldScore;
        public PlayerAchiveData[] WorldAchive;
        public PlayerStarData[] WorldStar;
        public PlayerBigStarData[] WorldBigStar;
        public PlayerTimeData[] WorldTime;
        public PlayerLifeData[] WorldLife;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public Player player;

    public float maxStageScore;
    public float stageScore;
    public int SitemNumber;
    public int stageIndex;
    public int savePoint;
    public float stageTime;

    public Image[] UIhealth;
    public Text UIStageScore1;
    public Text UIStageScore2;

    void Update()
    {
        UIStageScore1.text = stageScore.ToString();
        UIStageScore2.text = (stageScore / maxStageScore * 100) + "%".ToString();
    }
}

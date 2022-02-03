using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public Player player;

    public int maxStageScore;
    public int stageScore;
    public int SitemNumber;
    public int stageIndex;
    public int savePoint;
    public float stageTime;

    public Image[] UIhealth;
    public Text UIStageScore;
}

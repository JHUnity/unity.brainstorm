using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EItem : Item
{
    public int ItemScore;
    public void ItemAddScore()
    {
        GameManager.Instance.stageScore = GameManager.Instance.stageScore + ItemScore;
        uiManager.StageScore();
    }
}

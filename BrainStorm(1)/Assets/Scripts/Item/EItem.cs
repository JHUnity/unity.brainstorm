using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EItem : Item
{
    public int ItemScore;
    public void ItemAddScore()
    {
        gameManager.stageScore = gameManager.stageScore + ItemScore;
    }
}

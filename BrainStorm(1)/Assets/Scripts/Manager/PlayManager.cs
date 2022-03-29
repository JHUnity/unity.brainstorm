using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameObject[] Stage1;
    public GameObject[] Stage2;
    public GameObject[] Stage3;

    void Start()
    {
        StageChange();
    }

    void StageChange()
    {
        if(GameManager.Instance.stageIndex == 10001)
        {
            Stage1[0].SetActive(true);
            GameManager.Instance.stageMapSize = GameManager.Instance.stage1MapSize[1];
        }
        else
        {
            Stage1[0].SetActive(false);
        }
    }
}

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
            GameManager.Instance.stageMaxTime = 45;
            GameManager.Instance.mapSize = 50;
            Stage1[0].SetActive(true);
        }
        else
        {
            Stage1[0].SetActive(false);
        }
    }
}

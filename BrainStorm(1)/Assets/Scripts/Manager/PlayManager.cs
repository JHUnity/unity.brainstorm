using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameObject[] World1;
    public GameObject[] World2;
    public GameObject[] World3;

    void Start()
    {
        StageChange();
    }

    void StageChange()
    {
        if(GameManager.Instance.worldIndex == 1  && GameManager.Instance.stageIndex == 1)
        {
            World1[1].SetActive(true);
            GameManager.Instance.stageMapSize = GameManager.Instance.stage1MapSize[1];
        }
        else
        {
            World1[1].SetActive(false);
        }
    }
}

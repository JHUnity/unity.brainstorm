using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Map
{
    public GameObject[] StageMap;
}

public class PlayManager : MonoBehaviour
{
    public Map[] WorldMap;

    void Start()
    {
        StageChange();
    }

    void StageChange()
    {
        WorldMap[GameManager.Instance.worldIndex].StageMap[GameManager.Instance.stageIndex].SetActive(true);
        GameManager.Instance.stageMapSize = GameManager.Instance.WorldMaxSize[GameManager.Instance.worldIndex].StageMaxSize[GameManager.Instance.stageIndex];
    }
}

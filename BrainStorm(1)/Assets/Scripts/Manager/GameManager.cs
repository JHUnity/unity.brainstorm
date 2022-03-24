using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public float maxStageScore;
    public float stageScore;
    public int stageIndex;
    public int savePoint;
    public float itemActive;
    public float doorActive;
    public int SitemNumber;
    public float stageTime;
    public float stageMaxTime;

    public int mapSize;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if(obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<GameManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<GameManager>();
        if(objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        ItemActiveSet();
        DoorActiveSet();
        StageTimer();
    }

    void ItemActiveSet()
    {
        if (itemActive > 0)
        {
            itemActive--;
        }
    }
    void DoorActiveSet()
    {
        if (doorActive > 0)
        {
            doorActive--;
        }
    }

    void StageTimer()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            stageTime = stageTime + Time.deltaTime;
        }
        else
        {
            stageTime = 0;
        }
    }

    public void GameReset()
    {
        maxStageScore = 0;
        stageScore = 0;
        itemActive = 0;
        SitemNumber = 0;
        stageTime = 0;
        mapSize = 0;
    } 
}

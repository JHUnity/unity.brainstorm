using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerHP;

    public float maxStageScore;
    public float stageScore;
    public int worldIndex;
    public int stageIndex;
    public bool specialStage;
    public int savePoint;
    public float itemActive;
    public float doorActive;
    public int SitemNumber;

    public float stageTime;
    public int stageMapSize;

    public float[] stage1MaxTime;
    public float[] stage1aMaxTime;
    public float[] stage2MaxTime;
    public float[] stage2aMaxTime;
    public float[] stage3MaxTime;
    public float[] stage3aMaxTime;

    public int[] stage1MapSize;
    public int[] stage1aMapSize;
    public int[] stage2MapSize;
    public int[] stage2aMapSize;
    public int[] stage3MapSize;
    public int[] stage3aMapSize;

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
        stageMapSize = 0;
    } 
}

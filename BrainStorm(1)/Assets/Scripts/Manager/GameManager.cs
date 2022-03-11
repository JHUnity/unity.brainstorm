using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public float maxStageScore;
    public float stageScore;
    public int stageIndex;
    public int savePoint;
    public float itemActive;
    public int SitemNumber;
    public float stageTime;

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
    }

    void ItemActiveSet()
    {
        if (itemActive > 0)
        {
            itemActive--;
        }
    }

    

}

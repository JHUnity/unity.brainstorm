using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public Player player;
    public ObjectManager objManager;

    public float maxStageScore;
    public float stageScore;
    public int stageIndex;
    public int savePoint;
    public float itemActive;
    public int SitemNumber;
    public float stageTime;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        //uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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

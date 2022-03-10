using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Player player;
    //public GameManager gameManager;
    public ObjectManager objManager;
    public UIManager uiManager;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void DestroyItem()
    {
        gameObject.SetActive(false);
    }
}

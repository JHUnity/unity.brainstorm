using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject Menu;
    public GameObject scoreSetting1;
    public GameObject scoreSetting2;
    public Slider bgmVolume;
    public Slider seVolume;
    public GameObject itemUI;

    public bool Menuonoff;
    public bool Itemonoff;

    public bool ScoreSetting;
    public float BGMSetting;
    public float SESetting;

    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        //uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        ScoreSet1();
    }

    void Update()
    {
        BGMSetting = bgmVolume.value * 100;
        SESetting = seVolume.value * 100;
    }

    public void MenuButton()
    {
        if (Menuonoff == false)
        {
            Menu.SetActive(true);
            Menuonoff = true;
        }
        else
        {
            Menu.SetActive(false);
            Menuonoff = false;
        }
            
    }

    public void ScoreSet1()
    {
        scoreSetting1.SetActive(false);
        scoreSetting2.SetActive(true);
        ScoreSetting = false;
    }

    public void ScoreSet2()
    {
        scoreSetting1.SetActive(true);
        scoreSetting2.SetActive(false);
        ScoreSetting = true;
    }

    public void ItemSet()
    {
        if (Itemonoff == false)
        {
            itemUI.SetActive(true);
            Itemonoff = true;
        }
        else
        {
            itemUI.SetActive(false);
            Itemonoff = false;
        }
    }
}

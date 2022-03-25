﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public GameObject Menu;

    public GameObject scoreSetting1;
    public GameObject scoreSetting2;
    public Slider bgmVolume;
    public Slider seVolume;
    public GameObject ItemSetting1;
    public GameObject ItemSetting2;

    public GameObject quitButton;
    public GameObject quitPop;

    public GameObject retryButton;
    public GameObject retryPop1;
    public GameObject retryPop2;

    public GameObject clearPop;

    public bool Menuonoff;
    public bool Itemonoff;

    public bool ScoreSetting;
    public float BGMSetting;
    public float SESetting;

    private static SettingManager instance;
    public static SettingManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SettingManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SettingManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<SettingManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ScoreSetting = false;
        Itemonoff = true;
    }

    void Update()
    {
        BGMSetting = bgmVolume.value * 100;
        SESetting = seVolume.value * 100;

        QuitButtonActive();
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

    public void ScoreSet()
    {
        if (ScoreSetting == false)
        {
            scoreSetting1.SetActive(false);
            scoreSetting2.SetActive(true);
            ScoreSetting = true;
        }
        else
        {
            scoreSetting1.SetActive(true);
            scoreSetting2.SetActive(false);
            ScoreSetting = false;
        }
    }

    public void ItemSet()
    {
        if (Itemonoff == false)
        {
            ItemSetting1.SetActive(false);
            ItemSetting2.SetActive(true);
           
            Itemonoff = true;
        }
        else
        {
            ItemSetting1.SetActive(true);
            ItemSetting2.SetActive(false);

            Itemonoff = false;
        }
    }

    public void QuitPop()
    {
        Time.timeScale = 0;
        quitPop.SetActive(true);
    }

    public void QuitPopNo()
    {
        Time.timeScale = 1;
        quitPop.SetActive(false);
    }

    public void QuitPopYes()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex / 10000 * 10000;
        GameManager.Instance.GameReset();

        Menu.SetActive(false);
        Menuonoff = false;

        Time.timeScale = 1;
        quitPop.SetActive(false);
        SceneManager.LoadScene("Stage");
    }

    void QuitButtonActive()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            quitButton.SetActive(true);
            retryButton.SetActive(true);
        }
        else
        {
            quitButton.SetActive(false);
            retryButton.SetActive(false);
        }
    }

    public void RetryPop1()
    {
        Time.timeScale = 0;
        retryPop1.SetActive(true);
    }

    public void RetryPopNo1()
    {
        Time.timeScale = 1;
        retryPop1.SetActive(false);
    }

    public void RetryPopYes1()
    {
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        Menu.SetActive(false);
        retryPop1.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void RetryPop2()
    {
        Time.timeScale = 0;
        retryPop2.SetActive(true);
    }

    public void RetryPopNo2()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex / 10000 * 10000;
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        retryPop2.SetActive(false);
        SceneManager.LoadScene("Stage");
    }

    public void RetryPopYes2()
    {
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        retryPop2.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void ClearPop()
    {
        Time.timeScale = 0;
        clearPop.SetActive(true);
    }

    public void ClearPopNo()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex / 10000 * 10000;
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        clearPop.SetActive(false);
        SceneManager.LoadScene("Stage");
    }

    public void ClearPopYes()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex +1;
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        clearPop.SetActive(false);
        SceneManager.LoadScene("Game");
    }
}

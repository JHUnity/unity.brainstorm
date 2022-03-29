using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject[] Worlds;

    public GameObject startPop;

    public Text PopStage;
    public Text PopScore;
    public Text PopTime;
    public GameObject[] PopHealth;

    public GameObject[] Star;

    public void goWorld()
    {
        GameManager.Instance.stageIndex = 0;
        SceneManager.LoadScene("World");
    }

    public void goStage1()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex + 1;
        StartPop();
    }

    void Start()
    {
        StageSelect();
    }

    void Update()
    {

    }

    void StageSelect()
    {
        if (GameManager.Instance.stageIndex >= 10000 && (GameManager.Instance.stageIndex <= 19999))
        {
            GameManager.Instance.stageIndex = 10000;
            Worlds[1].SetActive(true);
        }
        else
        {
            Worlds[1].SetActive(false);
        }

        /*if (GameManager.Instance.stageIndex == 20000 && (GameManager.Instance.stageIndex <= 29999))
        {
        GameManager.Instance.stageIndex = 20000;
            Worlds[2].SetActive(true);
        }
        else
        {
            Worlds[2].SetActive(false);
        }
        */
    }

    void StartPop()
    {
        StartText();
        startPop.SetActive(true);
    }

    public void StartPopNo()
    {
        StageSelect();
        startPop.SetActive(false);
    }

    public void StartPopYes()
    {
        startPop.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    void StartText()
    {
        PopStage.text = "Stage " + (GameManager.Instance.stageIndex / 10000) + "-" + (GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)).ToString();

        PopScore.text = "Best Score : " + (UserManager.Instance.Stage1Score[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)]) 
            + " (" + (UserManager.Instance.Stage1Achive[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)]) + "%)".ToString();

        PopTime.text = "Best Time : " + (UserManager.Instance.Stage1Time[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)]) 
            + " / " + (GameManager.Instance.stage1MaxTime[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)]) + " sec".ToString();
        }
}

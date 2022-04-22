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
        GameManager.Instance.worldIndex = 0;
        SceneManager.LoadScene("World");
    }

    public void goStage1()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 1;
        StartPop();
    }

    public void goStage2()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 2;
        StartPop();
    }
    public void goStage3()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 3;
        StartPop();
    }

    public void goStage4()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 4;
        StartPop();
    }
    public void goStage5()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 5;
        StartPop();
    }
    public void goStage6()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 6;
        StartPop();
    }

    public void goStage7()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 7;
        StartPop();
    }
    public void goStage8()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 8;
        StartPop();
    }

    public void goStage9()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 9;
        StartPop();
    }
    public void goStage10()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 10;
        StartPop();
    }

    void Start()
    {
        StageSelect();
    }

    void StageSelect()
    {
        Worlds[GameManager.Instance.worldIndex].SetActive(true);
    }

    void StartPop()
    {
        StartText();
        startPop.SetActive(true);
    }

    public void StartPopNo()
    {
        StageSelect();
        GameManager.Instance.stageIndex = 0;

        Star[0].SetActive(false);
        Star[1].SetActive(false);
        Star[2].SetActive(false);
        Star[3].SetActive(false);
        Star[4].SetActive(false);

        startPop.SetActive(false);
    }

    public void StartPopYes()
    {
        startPop.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    void StartText()
    {
        PopStage.text = "World " + (GameManager.Instance.worldIndex) + "-" + (GameManager.Instance.stageIndex).ToString();
        PopScore.text = "Best Score : " + (UserManager.Instance.WorldScore[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex]) + " (" + (UserManager.Instance.WorldAchive[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] * 100) + "%)".ToString();
        PopTime.text = "Best Time : " + (UserManager.Instance.WorldTime[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex]) + " / " + (GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex]) + " sec".ToString();

        if (UserManager.Instance.WorldStar[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] >= 1)
        {
            Star[UserManager.Instance.WorldStar[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex]-1].SetActive(true);
        }
    }
}

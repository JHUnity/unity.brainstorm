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

    void Start()
    {
        StageSelect();
    }

    void Update()
    {

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

        if (GameManager.Instance.worldIndex == 1)
        {
            PopScore.text = "Best Score : " + (UserManager.Instance.World1Score[GameManager.Instance.stageIndex]) + " (" + (UserManager.Instance.World1Achive[GameManager.Instance.stageIndex]) + "%)".ToString();

            PopTime.text = "Best Time : " + (UserManager.Instance.World1Time[GameManager.Instance.stageIndex]) + " / " + (GameManager.Instance.stage1MaxTime[GameManager.Instance.stageIndex]) + " sec".ToString();
        }

        /*
        if (GameManager.Instance.stageIndex >= 20000 && (GameManager.Instance.stageIndex <= 29999))
        {
            PopScore.text = "Best Score : " + (UserManager.Instance.Stage2Score[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)])
            + " (" + (UserManager.Instance.Stage2Achive[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)]) + "%)".ToString();

            PopTime.text = "Best Time : " + (UserManager.Instance.Stage2Time[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)])
                + " / " + (GameManager.Instance.stage2MaxTime[GameManager.Instance.stageIndex - (GameManager.Instance.stageIndex / 10000 * 10000)]) + " sec".ToString();
        }
        */
    }
}

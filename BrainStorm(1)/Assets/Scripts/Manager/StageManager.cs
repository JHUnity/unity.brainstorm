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
        PopScore.text = "Best Score : " + (UserManager.Instance.WorldScore[GameManager.Instance.worldIndex].StageScore[GameManager.Instance.stageIndex]) + " (" + (UserManager.Instance.WorldAchive[GameManager.Instance.worldIndex].StageAchive[GameManager.Instance.stageIndex]) + "%)".ToString();
        PopTime.text = "Best Time : " + (UserManager.Instance.WorldTime[GameManager.Instance.worldIndex].StageTime[GameManager.Instance.stageIndex]) + " / " + (GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex]) + " sec".ToString();
    }
}

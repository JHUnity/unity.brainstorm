using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public UnlockedManager unSys;

    public GameObject[] Worlds;

    public GameObject startPop;
    public GameObject unlockedPop;

    public Text PopStage;
    public Text PopScore;
    public Text PopTime;
    public GameObject[] PopHealth;

    public Text unPopStage;
    public Text unPopNeedStar;
    public Text unPopNeedBigStar;
    public Text unPopAfterStar;
    public Text unPopAfterBigStar;

    public GameObject unlockedOn;

    public GameObject[] Star;

    void Update()
    {
        UnlockedOn();
    }

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
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }
    public void goStage3()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 3;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }

    public void goStage4()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 4;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }
    public void goStage5()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 5;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }
    public void goStage6()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 6;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }

    public void goStage7()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 7;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }
    public void goStage8()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 8;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }

    public void goStage9()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 9;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }
    public void goStage10()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 10;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
    }

    public void goStage31()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex = 31;
        if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] == true)
        {
            StartPop();
        }
        else
        {
            UnlockedPop();
        }
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

    void UnlockedPop()
    {
        UnlockedText();
        unlockedPop.SetActive(true);
    }

    public void UnlockedPopNo()
    {
        StageSelect();
        GameManager.Instance.stageIndex = 0;

        unlockedPop.SetActive(false);
    }

    public void UnlockedPopYes()
    {
        UserManager.Instance.star = UserManager.Instance.star - GameManager.Instance.UnlockWorldStar[GameManager.Instance.worldIndex].UnlockStageStar[GameManager.Instance.stageIndex];
        UserManager.Instance.bigStar = UserManager.Instance.bigStar - GameManager.Instance.UnlockWorldBigStar[GameManager.Instance.worldIndex].UnlockStageBigStar[GameManager.Instance.stageIndex];

        UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, GameManager.Instance.stageIndex] = true;
        unSys.UnlockedSystem();
        unlockedPop.SetActive(false);
        StartPop();
    }

    void UnlockedText()
    {
        unPopStage.text = "World " + (GameManager.Instance.worldIndex) + "-" + (GameManager.Instance.stageIndex).ToString();
        unPopNeedStar.text = "x" + (GameManager.Instance.UnlockWorldStar[GameManager.Instance.worldIndex].UnlockStageStar[GameManager.Instance.stageIndex]).ToString();
        unPopNeedBigStar.text = "x" + (GameManager.Instance.UnlockWorldBigStar[GameManager.Instance.worldIndex].UnlockStageBigStar[GameManager.Instance.stageIndex]).ToString();
        
    }

    void UnlockedOn()
    {
        if (GameManager.Instance.stageIndex >= 1)
        {
            if (UserManager.Instance.star >= GameManager.Instance.UnlockWorldStar[GameManager.Instance.worldIndex]
                .UnlockStageStar[GameManager.Instance.stageIndex] && UserManager.Instance.bigStar >= GameManager.Instance.UnlockWorldBigStar[GameManager.Instance.worldIndex]
                .UnlockStageBigStar[GameManager.Instance.stageIndex])
            {
                unlockedOn.SetActive(true);
                unPopAfterStar.text = "   →  x" + (UserManager.Instance.star - GameManager.Instance.UnlockWorldStar[GameManager.Instance.worldIndex].UnlockStageStar[GameManager.Instance.stageIndex]).ToString();
                unPopAfterBigStar.text = "   →  x" + (UserManager.Instance.bigStar - GameManager.Instance.UnlockWorldBigStar[GameManager.Instance.worldIndex].UnlockStageBigStar[GameManager.Instance.stageIndex]).ToString();
            }
            else
            {
                unlockedOn.SetActive(false);
            }
        }
    }
}

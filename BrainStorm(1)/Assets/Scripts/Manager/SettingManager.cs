using System.Collections;
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
    public GameObject TimerSetting1;
    public GameObject TimerSetting2;
    public GameObject StarSetting1;
    public GameObject StarSetting2;
    public GameObject StarBigStar;

    public GameObject quitButton;
    public GameObject quitPop;

    public GameObject retryButton;
    public GameObject retryPop1;
    public GameObject retryPop2;

    public GameObject clearPop;
    public Text clearStage;
    public Text clearScore;
    public Text clearTime;
    public GameObject[] clearLife;
    public GameObject[] clearStar;
    public GameObject clearButtons;

    public int starIf;
    public int starCalculate;
    public bool Menuonoff;
    public bool Itemonoff;

    public bool ScoreSetting;
    public float BGMSetting;
    public float SESetting;
    public bool TimerSetting;
    public bool StarSetting;

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
        TimerSetting = false;
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

    public void TimerSet()
    {
        if (TimerSetting == false)
        {
            TimerSetting1.SetActive(false);
            TimerSetting2.SetActive(true);

            TimerSetting = true;
        }
        else
        {
            TimerSetting1.SetActive(true);
            TimerSetting2.SetActive(false);

            TimerSetting = false;
        }
    }

    public void StarSet()
    {
        if (StarSetting == false)
        {
            StarSetting1.SetActive(false);
            StarSetting2.SetActive(true);
            StarBigStar.SetActive(false);

            StarSetting = true;
        }
        else
        {
            StarSetting1.SetActive(true);
            StarSetting2.SetActive(false);
            StarBigStar.SetActive(true);

            StarSetting = false;
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
        GameManager.Instance.stageIndex = 0;
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
        GameManager.Instance.stageIndex = 0;
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

        clearStage.text = "World " + (GameManager.Instance.worldIndex) + "-" + (GameManager.Instance.stageIndex) + " Clear!".ToString();
        clearScore.text = "Score : " + (GameManager.Instance.stageScore) + " (" + ((GameManager.Instance.stageScore) / (GameManager.Instance.maxStageScore) * 100) + "%)".ToString();
        clearTime.text = "Time : " + (GameManager.Instance.stageTime) + " / " + (GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex]) + " sec".ToString();

        if (GameManager.Instance.playerHP >= 1)
            clearLife[0].SetActive(true);
        if (GameManager.Instance.playerHP >= 2)
            clearLife[1].SetActive(true);
        if (GameManager.Instance.playerHP >= 3)
            clearLife[2].SetActive(true);

        //스테이지 결과 채점
        if (GameManager.Instance.stageTime / GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex] <= 1.2f)
        {
            starIf = starIf + 1;
        }

        if (GameManager.Instance.stageScore / GameManager.Instance.maxStageScore >= 0.85f)
        {
            starIf = starIf + 1;
        }

        if (GameManager.Instance.playerHP >= 2)
        {
            starIf = starIf + 1;
        }

        if (starIf >= 3)
        {
            int starIf4 = 0;
            if (GameManager.Instance.stageTime / GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex] <= 1.1f)
            {
                starIf4 = starIf4 + 1;
            }
            if (GameManager.Instance.stageScore / GameManager.Instance.maxStageScore >= 0.95f)
            {
                starIf4 = starIf4 + 1;
            }
            if (GameManager.Instance.playerHP >= 3)
            {
                starIf4 = starIf4 + 1;
            }
            if (starIf4 >= 2)
            {
                starIf = starIf + 1;
            }
            starIf4 = 0;
        }
       

        if (GameManager.Instance.stageTime / GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex] <= 1.0f
            && GameManager.Instance.stageScore / GameManager.Instance.maxStageScore >= 1.0f && GameManager.Instance.playerHP >= 3)
        {
            starIf = 5;
        }

        //별 획득 결과창
        clearStar[starIf - 1].SetActive(true);

        //별 획득, 저장
        if (starIf >= UserManager.Instance.WorldStar[GameManager.Instance.worldIndex].StageStar[GameManager.Instance.worldIndex])
        {
            UserManager.Instance.star = UserManager.Instance.star + (starIf - UserManager.Instance.WorldStar[GameManager.Instance.worldIndex].StageStar[GameManager.Instance.stageIndex]);
            UserManager.Instance.WorldStar[GameManager.Instance.worldIndex].StageStar[GameManager.Instance.stageIndex] = starIf;
        }

        if (starIf >= 5 && UserManager.Instance.WorldBigStar[GameManager.Instance.worldIndex].StageBigStar[GameManager.Instance.worldIndex] == false)
        {
            UserManager.Instance.bigStar = UserManager.Instance.bigStar + 1;
            UserManager.Instance.WorldBigStar[GameManager.Instance.worldIndex].StageBigStar[GameManager.Instance.worldIndex] = true;
        }

        //스테이지 기록 저장
        if (GameManager.Instance.stageTime <= UserManager.Instance.WorldTime[GameManager.Instance.worldIndex].StageTime[GameManager.Instance.stageIndex])
        {
            UserManager.Instance.WorldTime[GameManager.Instance.worldIndex].StageTime[GameManager.Instance.stageIndex] = GameManager.Instance.stageTime;
        }

        if (UserManager.Instance.WorldTime[GameManager.Instance.worldIndex].StageTime[GameManager.Instance.stageIndex] == 0)
        {
            UserManager.Instance.WorldTime[GameManager.Instance.worldIndex].StageTime[GameManager.Instance.stageIndex] = GameManager.Instance.stageTime;
        }

        if (GameManager.Instance.stageScore >= UserManager.Instance.WorldScore[GameManager.Instance.worldIndex].StageScore[GameManager.Instance.stageIndex])
        {
            UserManager.Instance.WorldScore[GameManager.Instance.worldIndex].StageScore[GameManager.Instance.stageIndex] = GameManager.Instance.stageScore;
        }

        if ((GameManager.Instance.stageScore / GameManager.Instance.maxStageScore) >= UserManager.Instance.WorldAchive[GameManager.Instance.worldIndex].StageAchive[GameManager.Instance.stageIndex])
        {
            UserManager.Instance.WorldAchive[GameManager.Instance.worldIndex].StageAchive[GameManager.Instance.stageIndex] = GameManager.Instance.stageScore / GameManager.Instance.maxStageScore;
        }

        if (GameManager.Instance.playerHP >= UserManager.Instance.WorldLife[GameManager.Instance.worldIndex].StageLife[GameManager.Instance.stageIndex])
        {
            UserManager.Instance.WorldLife[GameManager.Instance.worldIndex].StageLife[GameManager.Instance.stageIndex] = GameManager.Instance.playerHP;
        }

        //클리어 버튼 활성화
        clearButtons.SetActive(true);
    }

    void clearUIDisabled()
    {
        clearLife[0].SetActive(false);
        clearLife[1].SetActive(false);
        clearLife[2].SetActive(false);

        clearStar[0].SetActive(false);
        clearStar[1].SetActive(false);
        clearStar[2].SetActive(false);
        clearStar[3].SetActive(false);
        clearStar[4].SetActive(false);

        starIf = 0;

        clearButtons.SetActive(false);
    }

    public void ClearPopNo()
    {
        GameManager.Instance.stageIndex = 0;
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        clearPop.SetActive(false);
        clearUIDisabled();
        SceneManager.LoadScene("Stage");
    }

    public void ClearPopRe()
    {
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        clearPop.SetActive(false);
        clearUIDisabled();
        SceneManager.LoadScene("Game");
    }

    public void ClearPopYes()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex +1;
        GameManager.Instance.GameReset();

        Time.timeScale = 1;
        clearPop.SetActive(false);
        clearUIDisabled();
        SceneManager.LoadScene("Game");
    }
}

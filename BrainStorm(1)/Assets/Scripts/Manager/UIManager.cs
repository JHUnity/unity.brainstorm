using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public GameManager gameManager;
    //public SettingManager settingManager;

    public GameObject Skey1;
    public GameObject Skey2;

    public GameObject E_Slot;
    public GameObject EGun;
    public GameObject EFeather;

    public GameObject Score1;
    public GameObject Score2;

    public GameObject TimeR;

    public GameObject E_item;

    public GameObject AttackButton;

    public Text UIStageScore1;
    public Text UIStageScore2;
    public Image[] UIhealth;
    public Text UITimer;

    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        //uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        StageScore();
    }

    void Update()
    {
        StageScore();
        StageItem();
        EternityItem();
        Score();
        Timer();
    }

    public void StageScore()
    {
        UIStageScore1.text = "Score : " + (GameManager.Instance.stageScore).ToString();
        UIStageScore2.text = "Achievement : " + (GameManager.Instance.stageScore / GameManager.Instance.maxStageScore * 100) + "%".ToString();
        UITimer.text = (GameManager.Instance.stageTime) + " /  " + GameManager.Instance.WorldMaxTime[GameManager.Instance.worldIndex].StageMaxTime[GameManager.Instance.stageIndex] + " sec".ToString();
    }

    void StageItem()
    {
        if (GameManager.Instance.SitemNumber == 1)
        {
            Skey1.SetActive(true);
        }
        else
        {
            Skey1.SetActive(false);
        }

        if (GameManager.Instance.SitemNumber == 2)
        {
            Skey2.SetActive(true);
        }
        else
        {
            Skey2.SetActive(false);
        }
    }

    void EternityItem()
    {
        if (UserManager.Instance.ItemSetting == false)
        {
            E_item.SetActive(false);
        }
        else
        {
            E_item.SetActive(true);
        }
    }

    void Score()
    {
        if (UserManager.Instance.ScoreSetting == false)
        {
            Score1.SetActive(true);
            Score2.SetActive(false);
        }
        else
        {
            Score1.SetActive(false);
            Score2.SetActive(true);
        }
    }

    void Timer()
    {
        if (UserManager.Instance.TimerSetting == false)
        {
            TimeR.SetActive(false);
        }
        else
        {
            TimeR.SetActive(true);
        }
    }

    public void EItem_1()
    {
        EGun.SetActive(true);
        EGun.transform.position = E_Slot.transform.position;
        SlotMove();
    }

    public void EItem_2()
    {
        EFeather.SetActive(true);
        EFeather.transform.position = E_Slot.transform.position;
        SlotMove();
    }

    void SlotMove()
    {
        if (E_Slot.gameObject.transform.position.x != 480)
        {
            E_Slot.gameObject.transform.Translate(new Vector3(96, 0, 0));
        }
        else
        {
            E_Slot.gameObject.transform.Translate(new Vector3(-480, 96, 0));
        }
    }
}

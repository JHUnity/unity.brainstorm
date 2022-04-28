using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public GameObject unlockedPop;

    public Text unPopStage;
    public Text unPopNeedStar;
    public Text unPopNeedBigStar;
    public Text unPopAfterStar;
    public Text unPopAfterBigStar;

    public GameObject unlockedOn;
    public GameObject[] Lock;

    void Start()
    {
        LockShow();
    }

    void Update()
    {
        UnlockedOn();
    }

    public void goLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void goWorld1()
    {
        GameManager.Instance.worldIndex = 1;
        SceneManager.LoadScene("Stage");
    }

    public void goWorld2()
    {
        GameManager.Instance.worldIndex = 2;
        if (UserManager.Instance.WorldUnlock[GameManager.Instance.worldIndex] == true)
        {
            SceneManager.LoadScene("Stage");
        }
        else
        {
            UnlockedPop();
        }
        
    }

    void UnlockedPop()
    {
        UnlockedText();
        unlockedPop.SetActive(true);
    }

    public void UnlockedPopNo()
    {
        GameManager.Instance.worldIndex = 0;

        unlockedPop.SetActive(false);
    }

    public void UnlockedPopYes()
    {
        UserManager.Instance.star = UserManager.Instance.star - GameManager.Instance.WorldUnlockStar[GameManager.Instance.worldIndex];
        UserManager.Instance.bigStar = UserManager.Instance.bigStar - GameManager.Instance.WorldUnlockBigStar[GameManager.Instance.worldIndex];

        UserManager.Instance.WorldUnlock[GameManager.Instance.worldIndex] = true;
        unlockedPop.SetActive(false);

        LockShow();
    }

    void UnlockedText()
    {
        unPopStage.text = "World " + (GameManager.Instance.worldIndex).ToString();
        unPopNeedStar.text = "x" + (GameManager.Instance.WorldUnlockStar[GameManager.Instance.worldIndex]).ToString();
        unPopNeedBigStar.text = "x" + (GameManager.Instance.WorldUnlockBigStar[GameManager.Instance.worldIndex]).ToString();

    }

    void UnlockedOn()
    {
        if (GameManager.Instance.worldIndex >= 1)
        {
            if (UserManager.Instance.star >= GameManager.Instance.WorldUnlockStar[GameManager.Instance.worldIndex]
                && UserManager.Instance.bigStar >= GameManager.Instance.WorldUnlockBigStar[GameManager.Instance.worldIndex])
            {
                unlockedOn.SetActive(true);
                unPopAfterStar.text = "   →  x" + (UserManager.Instance.star - GameManager.Instance.WorldUnlockStar[GameManager.Instance.worldIndex]).ToString();
                unPopAfterBigStar.text = "   →  x" + (UserManager.Instance.bigStar - GameManager.Instance.WorldUnlockBigStar[GameManager.Instance.worldIndex]).ToString();
            }
            else
            {
                unlockedOn.SetActive(false);
            }
        }
    }

    void LockShow()
    {
        for (int i = 2; i < Lock.Length; i++)
        {
            if (UserManager.Instance.WorldUnlock[GameManager.Instance.worldIndex] == true)
            {
                Lock[i].SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject[] Worlds;

    public void goWorld()
    {
        GameManager.Instance.stageIndex = 0;
        SceneManager.LoadScene("World");
    }

    public void goStage1()
    {
        GameManager.Instance.stageIndex = GameManager.Instance.stageIndex + 1;
        SceneManager.LoadScene("Game");
    }

    void Update()
    {
        StageSelect();
    }

    void StageSelect()
    {
        if (GameManager.Instance.stageIndex == 10000)
        {
            Worlds[0].SetActive(true);
        }
        else
        {
            Worlds[0].SetActive(false);
        }

        /*if (GameManager.Instance.stageIndex == 20000)
        {
            Worlds[1].SetActive(true);
        }
        else
        {
            Worlds[1].SetActive(false);
        }
        */
    }
}

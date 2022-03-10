using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public void goWorld()
    {
        SceneManager.LoadScene("World");
    }

    public void goStage10001()
    {
        SceneManager.LoadScene("Game");
    }
}

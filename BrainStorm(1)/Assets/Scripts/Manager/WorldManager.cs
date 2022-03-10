using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public void goLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void goStage1()
    {
        SceneManager.LoadScene("Stage");
    }
}

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

    public void goWorld1()
    {
        GameManager.Instance.worldIndex = 1;
        SceneManager.LoadScene("Stage");
    }
}

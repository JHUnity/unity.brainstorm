using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedManager : MonoBehaviour
{
    public GameObject[] NormalUnlocked;

    void Start()
    {
        UnlockedSystem();
    }

    public void UnlockedSystem()
    {
        for (int i = 2; i < NormalUnlocked.Length; i++)
        {
            if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, i] == true)
            {
                NormalUnlocked[i].SetActive(true);
            }
        }
    }
}

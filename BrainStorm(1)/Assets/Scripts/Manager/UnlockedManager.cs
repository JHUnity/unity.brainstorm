using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedManager : MonoBehaviour
{
    public GameObject[] NormalUnlocked;
    public GameObject[] SpecialUnlocked;

    void Start()
    {
        for (int i = 2; i < NormalUnlocked.Length; i++)
        {
            if (UserManager.Instance.WorldNormalUnlock[GameManager.Instance.worldIndex, i] == true)
            {
                NormalUnlocked[i].SetActive(true);
            }
        }

        for (int i = 1; i < SpecialUnlocked.Length; i++)
        {
            if (UserManager.Instance.WorldSpecialUnlock[GameManager.Instance.worldIndex, i] == true)
            {
                SpecialUnlocked[i].SetActive(true);
            }
        }
    }
}

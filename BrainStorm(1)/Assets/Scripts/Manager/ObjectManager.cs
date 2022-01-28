using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Player_Bullet1Prefab;

    GameObject[] Player_Bullet1;

    GameObject[] targetpool;

    void Awake()
    {
        Player_Bullet1 = new GameObject[15];

        Generate();
    }

    void Generate()
    {
        for(int index = 0; index < Player_Bullet1.Length; index++)
        {
            Player_Bullet1[index] = Instantiate(Player_Bullet1Prefab);
            Player_Bullet1[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "Player_Bullet1":
                targetpool = Player_Bullet1;
                break;
        }

        for (int index = 0; index < targetpool.Length; index++)
        {
            if (!targetpool[index].activeSelf)
            {
                targetpool[index].SetActive(true);
                return targetpool[index];
            }
        }
        return null;
    }
}

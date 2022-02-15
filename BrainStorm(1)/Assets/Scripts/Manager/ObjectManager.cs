using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Player_Bullet1Prefab;
    public GameObject SItem_Key1Prefab;
    public GameObject EItem_FeatherPrefab;
    public Player _myPlayer;

    public int Player_Bullet1Count = 6;
    public int SItem_Key1Count = 1;
    public int EItem_FeatherCount = 1;

    GameObject[] Player_Bullet1;
    GameObject[] SItem_Key1;
    GameObject[] EItem_Feather;

    GameObject[] targetpool;

    void Awake()
    {
        Player_Bullet1 = new GameObject[Player_Bullet1Count];
        SItem_Key1 = new GameObject[SItem_Key1Count];
        EItem_Feather = new GameObject[EItem_FeatherCount];

        Generate();
    }

    void Generate()
    {
        for(int index = 0; index < Player_Bullet1.Length; index++)
        {
            Player_Bullet1[index] = Instantiate(Player_Bullet1Prefab);
            Player_Bullet1[index].SetActive(false);
        }
        for (int index = 0; index < SItem_Key1.Length; index++)
        {
            SItem_Key1[index] = Instantiate(SItem_Key1Prefab);
            SItem_Key1[index].SetActive(false);
        }
        for (int index = 0; index < EItem_Feather.Length; index++)
        {
            EItem_Feather[index] = Instantiate(EItem_FeatherPrefab);
            EItem_Feather[index].SetActive(false);
            EItem_Feather tmp = EItem_Feather[index].GetComponent<EItem_Feather>();
            tmp.player = _myPlayer;

        }
    }

    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "Player_Bullet1":
                targetpool = Player_Bullet1;
                break;
            case "SItem_Key1":
                targetpool = SItem_Key1;
                break;
            case "EItem_Feather":
                targetpool = EItem_Feather;
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

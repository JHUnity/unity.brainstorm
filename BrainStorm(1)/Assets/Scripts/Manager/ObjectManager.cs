using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;
    public ObjectManager objManager;
    public UIManager uiManager;

    GameObject[] Player_Bullet1;
    public int Player_Bullet1Count;
    public GameObject Player_Bullet1Prefab;

    GameObject[] SItem_Key1;
    public int SItem_Key1Count;
    public GameObject SItem_Key1Prefab;

    GameObject[] SItem_Key2;
    public int SItem_Key2Count;
    public GameObject SItem_Key2Prefab;

    GameObject[] EItem_Gun;
    public int EItem_GunCount;
    public GameObject EItem_GunPrefab;

    GameObject[] EItem_Feather;
    public int EItem_FeatherCount;
    public GameObject EItem_FeatherPrefab;

    GameObject[] targetpool;

    void Awake()
    {
        Player_Bullet1 = new GameObject[Player_Bullet1Count];
        SItem_Key1 = new GameObject[SItem_Key1Count];
        SItem_Key2 = new GameObject[SItem_Key2Count];
        EItem_Gun = new GameObject[EItem_GunCount];
        EItem_Feather = new GameObject[EItem_FeatherCount];

        Generate();
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Generate()
    {

        for (int index = 0; index < Player_Bullet1.Length; index++)
        {
            Player_Bullet1[index] = Instantiate(Player_Bullet1Prefab);
            Player_Bullet1[index].SetActive(false);
        }

        /*
        for (int index = 0; index < SItem_Key1.Length; index++)
        {
            SItem_Key1[index] = Instantiate(SItem_Key1Prefab);
            SItem_Key1[index].SetActive(false);
            SItem_Key1 tmp = SItem_Key1[index].GetComponent<SItem_Key1>();
            tmp.player = player;
            tmp.gameManager = gameManager;
            tmp.objManager = objManager;
            tmp.uiManager = uiManager;
        }

        for (int index = 0; index < SItem_Key2.Length; index++)
        {
            SItem_Key2[index] = Instantiate(SItem_Key2Prefab);
            SItem_Key2[index].SetActive(false);
            SItem_Key2 tmp = SItem_Key2[index].GetComponent<SItem_Key2>();
            tmp.player = player;
            tmp.gameManager = gameManager;
            tmp.objManager = objManager;
            tmp.uiManager = uiManager;
        }

        for (int index = 0; index < EItem_Gun.Length; index++)
        {
            EItem_Gun[index] = Instantiate(EItem_GunPrefab);
            EItem_Gun[index].SetActive(false);
            EItem_Gun tmp = EItem_Gun[index].GetComponent<EItem_Gun>();
            tmp.player = player;
            tmp.gameManager = gameManager;
            tmp.objManager = objManager;
            tmp.uiManager = uiManager;
        }

        
        for (int index = 0; index < EItem_Feather.Length; index++)
        {
            EItem_Feather[index] = Instantiate(EItem_FeatherPrefab);
            EItem_Feather[index].SetActive(false);
            EItem_Feather tmp = EItem_Feather[index].GetComponent<EItem_Feather>();
            tmp.player = player;
            tmp.gameManager = gameManager;
            tmp.objManager = objManager;
            tmp.uiManager = uiManager;
        }
        */

        ItemCreate<SItem_Key1>(SItem_Key1, SItem_Key1Prefab);
        ItemCreate<SItem_Key2>(SItem_Key2, SItem_Key2Prefab);
        ItemCreate<EItem_Gun>(EItem_Gun, EItem_GunPrefab);
        ItemCreate<EItem_Feather>(EItem_Feather, EItem_FeatherPrefab);
    }

    void ItemCreate<T>(GameObject[] item, GameObject pref) where T : Item
    {
        for (int index = 0; index < EItem_Feather.Length; index++)
        {
            item[index] = Instantiate(pref);
            item[index].SetActive(false);
            T tmp = item[index].GetComponent<T>();
            tmp.player = player;
            tmp.gameManager = gameManager;
            tmp.objManager = objManager;
            tmp.uiManager = uiManager;
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
            case "SItem_Key2":
                targetpool = SItem_Key2;
                break;
            case "EItem_Gun":
                targetpool = EItem_Gun;
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

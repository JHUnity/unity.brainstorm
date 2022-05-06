using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //public Player player;
    //public GameManager gameManager;
    //public ObjectManager objManager;
    //public UIManager uiManager;

    GameObject[] Player_Bullet1;
    public int Player_Bullet1Count;
    public GameObject Player_Bullet1Prefab;

    GameObject[] Monster_Bullet1;
    public int Monster_Bullet1Count;
    public GameObject Monster_Bullet1Prefab;


    GameObject[] SItem_Key1;
    public int SItem_Key1Count;
    public GameObject SItem_Key1Prefab;

    GameObject[] SItem_Key2;
    public int SItem_Key2Count;
    public GameObject SItem_Key2Prefab;

    GameObject[] SItem_Key3;
    public int SItem_Key3Count;
    public GameObject SItem_Key3Prefab;

    GameObject[] SItem_Key4;
    public int SItem_Key4Count;
    public GameObject SItem_Key4Prefab;

    GameObject[] SItem_Key5;
    public int SItem_Key5Count;
    public GameObject SItem_Key5Prefab;

    GameObject[] SItem_Key6;
    public int SItem_Key6Count;
    public GameObject SItem_Key6Prefab;

    GameObject[] SItem_Key7;
    public int SItem_Key7Count;
    public GameObject SItem_Key7Prefab;

    GameObject[] SItem_Shoes;
    public int SItem_ShoesCount;
    public GameObject SItem_ShoesPrefab;

    GameObject[] EItem_Gun;
    public int EItem_GunCount;
    public GameObject EItem_GunPrefab;

    GameObject[] EItem_Feather;
    public int EItem_FeatherCount;
    public GameObject EItem_FeatherPrefab;


    GameObject[] Monster_Slime;
    public int Monster_SlimeCount;
    public GameObject Monster_SlimePrefab;

    GameObject[] Monster_Bat;
    public int Monster_BatCount;
    public GameObject Monster_BatPrefab;


    GameObject[] targetpool;

    void Awake()
    {
        Player_Bullet1 = new GameObject[Player_Bullet1Count];
        Monster_Bullet1 = new GameObject[Monster_Bullet1Count];

        SItem_Key1 = new GameObject[SItem_Key1Count];
        SItem_Key2 = new GameObject[SItem_Key2Count];
        SItem_Key3 = new GameObject[SItem_Key3Count];
        SItem_Key4 = new GameObject[SItem_Key4Count];
        SItem_Key5 = new GameObject[SItem_Key5Count];
        SItem_Key6 = new GameObject[SItem_Key6Count];
        SItem_Key7 = new GameObject[SItem_Key7Count];
        SItem_Shoes = new GameObject[SItem_ShoesCount];
        EItem_Gun = new GameObject[EItem_GunCount];
        EItem_Feather = new GameObject[EItem_FeatherCount];

        Monster_Slime = new GameObject[Monster_SlimeCount];
        Monster_Bat = new GameObject[Monster_BatCount];

        Generate();
    }

    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        //uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Generate()
    {
        BulletCreate<Bullet>(Player_Bullet1, Player_Bullet1Prefab);
        BulletCreate<Bullet>(Monster_Bullet1, Monster_Bullet1Prefab);

        ItemCreate<Item>(SItem_Key1, SItem_Key1Prefab);
        ItemCreate<Item>(SItem_Key2, SItem_Key2Prefab);
        ItemCreate<Item>(SItem_Key3, SItem_Key3Prefab);
        ItemCreate<Item>(SItem_Key4, SItem_Key4Prefab);
        ItemCreate<Item>(SItem_Key5, SItem_Key5Prefab);
        ItemCreate<Item>(SItem_Key6, SItem_Key6Prefab);
        ItemCreate<Item>(SItem_Key7, SItem_Key7Prefab);
        ItemCreate<Item>(SItem_Shoes, SItem_ShoesPrefab);
        ItemCreate<Item>(EItem_Gun, EItem_GunPrefab);
        ItemCreate<Item>(EItem_Feather, EItem_FeatherPrefab);

        MonsterCreate<Monster>(Monster_Slime, Monster_SlimePrefab);
        MonsterCreate<Monster>(Monster_Bat, Monster_BatPrefab);
    }

    void BulletCreate<T>(GameObject[] bullet, GameObject pref) where T : Bullet
    {
        for (int index = 0; index < bullet.Length; index++)
        {
            bullet[index] = Instantiate(pref);
            bullet[index].SetActive(false);
        }
    }

    void ItemCreate<T>(GameObject[] item, GameObject pref) where T : Item
    {
        for (int index = 0; index < item.Length; index++)
        {
            item[index] = Instantiate(pref);
            item[index].SetActive(false);
        }
    }

    void MonsterCreate<T>(GameObject[] monster, GameObject pref) where T : Monster
    {
        for (int index = 0; index < monster.Length; index++)
        {
            monster[index] = Instantiate(pref);
            monster[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "Player_Bullet1":
                targetpool = Player_Bullet1;
                break;
            case "Monster_Bullet1":
                targetpool = Monster_Bullet1;
                break;

            case "SItem_Key1":
                targetpool = SItem_Key1;
                break;
            case "SItem_Key2":
                targetpool = SItem_Key2;
                break;
            case "SItem_Key3":
                targetpool = SItem_Key3;
                break;
            case "SItem_Key4":
                targetpool = SItem_Key4;
                break;
            case "SItem_Key5":
                targetpool = SItem_Key5;
                break;
            case "SItem_Key6":
                targetpool = SItem_Key6;
                break;
            case "SItem_Key7":
                targetpool = SItem_Key7;
                break;
            case "SItem_Shoes":
                targetpool = SItem_Shoes;
                break;
            case "EItem_Gun":
                targetpool = EItem_Gun;
                break;
            case "EItem_Feather":
                targetpool = EItem_Feather;
                break;

            case "Monster_Slime":
                targetpool = Monster_Slime;
                break;
            case "Monster_Bat":
                targetpool = Monster_Bat;
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

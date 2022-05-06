using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ObjectManager objManager;

    public GameObject Spawner;

    public Transform[] Slime;
    public Transform[] Bat;

    public Transform[] Key1;
    public Transform[] Key2;
    public Transform[] Key3;
    public Transform[] Key4;
    public Transform[] Key5;
    public Transform[] Key6;
    public Transform[] Key7;
    public Transform[] Shoes;

    public Transform[] Feather;
    public Transform[] Gun;

    public GameObject[] Door;

    void Start()
    {
        objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

        spawnSlime();
        spawnBat();

        spawnKey1();
        spawnKey2();
        spawnKey3();
        spawnKey4();
        spawnKey5();
        spawnKey6();
        spawnKey7();
        spawnShoes();

        spawnFeather();
        spawnGun();

        spawnDoor();
    }

    void spawnSlime()
    {
        for (int i = 0; i < Slime.Length; i++)
        {
            Spawner = objManager.MakeObj("Monster_Slime");
            Spawner.transform.position = Slime[i].position;
            GameManager.Instance.maxStageScore = GameManager.Instance.maxStageScore + 20;
        }
    }

    void spawnBat()
    {
        for (int i = 0; i < Bat.Length; i++)
        {
            Spawner = objManager.MakeObj("Monster_Bat");
            Spawner.transform.position = Bat[i].position;
            GameManager.Instance.maxStageScore = GameManager.Instance.maxStageScore + 20;
        }
    }

    void spawnKey1()
    {
        for (int i = 0; i < Key1.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key1");
            Spawner.transform.position = Key1[i].position;
        }
    }

    void spawnKey2()
    {
        for (int i = 0; i < Key2.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key2");
            Spawner.transform.position = Key2[i].position;
        }
    }

    void spawnKey3()
    {
        for (int i = 0; i < Key3.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key3");
            Spawner.transform.position = Key3[i].position;
        }
    }

    void spawnKey4()
    {
        for (int i = 0; i < Key4.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key4");
            Spawner.transform.position = Key4[i].position;
        }
    }

    void spawnKey5()
    {
        for (int i = 0; i < Key5.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key5");
            Spawner.transform.position = Key5[i].position;
        }
    }

    void spawnKey6()
    {
        for (int i = 0; i < Key6.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key6");
            Spawner.transform.position = Key6[i].position;
        }
    }

    void spawnKey7()
    {
        for (int i = 0; i < Key7.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Key7");
            Spawner.transform.position = Key7[i].position;
        }
    }

    void spawnShoes()
    {
        for (int i = 0; i < Shoes.Length; i++)
        {
            Spawner = objManager.MakeObj("SItem_Shoes");
            Spawner.transform.position = Shoes[i].position;
        }
    }

    void spawnFeather()
    {
        for (int i = 0; i < Feather.Length; i++)
        {
            Spawner = objManager.MakeObj("EItem_Feather");
            Spawner.transform.position = Feather[i].position;
            GameManager.Instance.maxStageScore = GameManager.Instance.maxStageScore + 500;
        }
    }

    void spawnGun()
    {
        for (int i = 0; i < Gun.Length; i++)
        {
            Spawner = objManager.MakeObj("EItem_Gun");
            Spawner.transform.position = Gun[i].position;
            GameManager.Instance.maxStageScore = GameManager.Instance.maxStageScore + 500;
        }
    }

    void spawnDoor()
    {
        for (int i = 0; i < Door.Length; i++)
        {
            GameManager.Instance.maxStageScore = GameManager.Instance.maxStageScore + 500;
        }
    }
}

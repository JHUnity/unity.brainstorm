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

    public Transform[] Feather;
    public Transform[] Gun;

    void Start()
    {
        objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

        spawnSlime();
        spawnBat();

        spawnKey1();
        spawnKey2();

        spawnFeather();
        spawnGun();
    }

    void spawnSlime()
    {
        for (int i = 0; i < Slime.Length; i++)
        {
            Spawner = objManager.MakeObj("Monster_Slime");
            Spawner.transform.position = Slime[i].position;
        }
    }

    void spawnBat()
    {
        for (int i = 0; i < Bat.Length; i++)
        {
            Spawner = objManager.MakeObj("Monster_Bat");
            Spawner.transform.position = Bat[i].position;
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

    void spawnFeather()
    {
        for (int i = 0; i < Feather.Length; i++)
        {
            Spawner = objManager.MakeObj("EItem_Feather");
            Spawner.transform.position = Feather[i].position;
        }
    }

    void spawnGun()
    {
        for (int i = 0; i < Gun.Length; i++)
        {
            Spawner = objManager.MakeObj("EItem_Gun");
            Spawner.transform.position = Gun[i].position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject scoreSetting1;
    public GameObject scoreSetting2;
    public Slider bgmVolume;
    public Slider seVolume;

    public bool Menuonoff;
    public bool Itemonoff;

    public bool ScoreSetting;
    public float BGMSetting;
    public float SESetting;

    private static SettingManager instance;
    public static SettingManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SettingManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SettingManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<SettingManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ScoreSet1();
    }

    void Update()
    {
        BGMSetting = bgmVolume.value * 100;
        SESetting = seVolume.value * 100;
    }

    public void MenuButton()
    {
        if (Menuonoff == false)
        {
            Menu.SetActive(true);
            Menuonoff = true;
        }
        else
        {
            Menu.SetActive(false);
            Menuonoff = false;
        }
            
    }

    public void ScoreSet1()
    {
        scoreSetting1.SetActive(false);
        scoreSetting2.SetActive(true);
        ScoreSetting = false;
    }

    public void ScoreSet2()
    {
        scoreSetting1.SetActive(true);
        scoreSetting2.SetActive(false);
        ScoreSetting = true;
    }

    public void ItemSet()
    {
        if (Itemonoff == false)
        {
            Itemonoff = true;
        }
        else
        {
            Itemonoff = false;
        }
    }
}

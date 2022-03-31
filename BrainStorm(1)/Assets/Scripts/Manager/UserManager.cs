using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public int star;
    public int bigStar;

    public float[] World1Score;
    public float[] World1Achive;
    public int[] World1Star;
    public int[] World1Time;
    public int[] World1Life;

    private static UserManager instance;
    public static UserManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<UserManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<UserManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<UserManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}

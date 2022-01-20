using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int hp;
    public float movePower;
    public float jumpPower;

    public Rigidbody2D rigid;
    public Vector3 movement;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int hp;
    public float maxSpeed;
    public float jumpPower;

    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D capsuleCollider;
    public Animator anim;
    public Vector3 movement;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }
}
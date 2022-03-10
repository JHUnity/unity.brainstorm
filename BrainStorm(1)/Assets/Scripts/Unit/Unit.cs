using System.Collections;
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

    public Player player;
    public UIManager uiManager;
    public ObjectManager objManager;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        anim = gameObject.GetComponent<Animator>();

        player = GameObject.Find("Player").GetComponent<Player>();
        objManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
}

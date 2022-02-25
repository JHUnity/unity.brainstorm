using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float destroyBulletTime;
    public float destroyBullet;

    public Rigidbody2D rigid;
    public Animator anim;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void OnEnable()
    {
        destroyBullet = destroyBulletTime;
    }

    void Update()
    {
        destroyBullet = destroyBullet - 1;

        if (destroyBullet <= 0)
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    public void ExplosionBullet()
    {
        destroyBullet = 120;
        rigid.velocity = Vector3.zero;
        anim.SetTrigger("BulletHit");
    }
}

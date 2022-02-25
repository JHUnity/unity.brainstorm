using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Monster
{
    public float bulletSpeed;
    public float coolTime;
    public float curTime;

    void Update()
    {
        Attak();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            hp = hp - 1;
            if (hp >= 1)
            {
                anim.SetTrigger("isDamaged");
            }
            else
            {
                MosterDie();
            }
        }

    }

    void Move()
    {
        rigid.velocity = new Vector2(nextMove * maxSpeed, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0, 255));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("PlatformColider"));
        if (rayHit.collider == null & spriteRenderer.flipY == false)
        {
            Turn();
        }
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
    }

    void Attak()
    {
        //공격
        if (curTime <= 0)
        {
            GameObject MonsterBullet = objManager.MakeObj("Monster_Bullet1");
            MonsterBullet.transform.position = transform.position;
            Rigidbody2D rigid = MonsterBullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.zero * bulletSpeed, ForceMode2D.Impulse);
            curTime = coolTime;
        }
        curTime -= Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public Transform pos;

    public float coolTime;
    private float curTime;

    public float bulletSpeed;
    int bulletDir = 1;

    public ObjectManager objManager;

    void Update() 
    {
        Move();
        Attak();
    }

    void FixedUpdate()
    {
        //이동
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //최고속도
        if (rigid.velocity.x > maxSpeed) //우방향 최고속도
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) //좌방향 최고속도
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //착지 애니메이션 변경
        if (rigid.velocity.y < 0)
        {
            float i;
            for (i = -0.4f; i <= 0.8; i = i+0.4f)
            {
                Vector2 velocityVec = new Vector2(rigid.position.x + i, rigid.position.y);
                Debug.DrawRay(velocityVec, new Vector3(0, -1, 0), new Color(0, 1, 0, 255));
                RaycastHit2D rayHit = Physics2D.Raycast(velocityVec, new Vector3(0, -1, 0), 1, LayerMask.GetMask("Platform"));
                if (rayHit.collider != null)
                {
                    if (rayHit.distance <= 0.5f)
                    {
                        anim.SetBool("isJumping", false);
                    }
                }
            }
            
        }
        if ((Mathf.Abs(rigid.velocity.y) == 0) && anim.GetBool("isJumping"))
        {
            anim.SetBool("isJumping", false);
        }
    }

    void Move()
    {
        //점프
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        //감속
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //스프라이트 반전
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            if(spriteRenderer.flipX == true)
                bulletDir = -1;
            if (spriteRenderer.flipX == false)
                bulletDir = 1;

        }

        //애니메이션 변경
        if (Mathf.Abs(rigid.velocity.x) < 0.2)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    void Attak()
    {
        //공격
        if(curTime <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
               GameObject PlayerBullet = objManager.MakeObj("Player_Bullet1");
               PlayerBullet.transform.position = pos.position;
               Rigidbody2D rigid = PlayerBullet.GetComponent<Rigidbody2D>();
               rigid.AddForce(Vector2.right * bulletDir * bulletSpeed, ForceMode2D.Impulse);
            }
            curTime = coolTime;
        }
        curTime -= Time.deltaTime;
    }
}

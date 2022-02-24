using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public Transform pos;
    public Transform itemDrop;

    public float coolTime;
    private float curTime;

    public float bulletSpeed;
    int bulletDir = 1;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;
    public bool inputAttack = false;

    public bool EItem_Gun = false;

    void Update() 
    {
        KeyUpdate();

        PlayerStop();
        PlayerJump();
        PlayerDirection();
        PlayerAnimation();
        PlayerAttak();
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerLanding();
    }

    void KeyUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            inputLeft = true;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            inputLeft = false;

        if (Input.GetKey(KeyCode.RightArrow))
            inputRight = true;
        if (Input.GetKeyUp(KeyCode.RightArrow))
            inputRight = false;

        if (Input.GetKey(KeyCode.Space))
            inputJump = true;
        if (Input.GetKeyUp(KeyCode.Space))
            inputJump = false;

        if (Input.GetKey(KeyCode.LeftControl) & EItem_Gun == true)
            inputAttack = true;
        if (Input.GetKeyUp(KeyCode.LeftControl))
            inputAttack = false;
    }

    void PlayerStop()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }

    void PlayerJump()
    {
        if (inputJump == true & !anim.GetBool("isJumping"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }

    void PlayerDirection()
    {
        if (inputRight == true & inputLeft == false)
        {
            spriteRenderer.flipX = false;
        }
        if (inputRight == false & inputLeft == true)
        {
            spriteRenderer.flipX = true;
        }

        if (spriteRenderer.flipX == true)
        {
            bulletDir = -1;
        }
        else
        {
            bulletDir = 1;
        }
    }

    void PlayerAnimation()
    {
        if (Mathf.Abs(rigid.velocity.x) < 0.2)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    void PlayerAttak()
    {
        //공격
        if (curTime <= 0)
        {
            if (inputAttack == true)
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

    void PlayerMove()
    {
        if (inputRight == true & inputLeft == false)
        {
            rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);

            if (rigid.velocity.x > maxSpeed)
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }

        if (inputRight == false & inputLeft == true)
        {
            rigid.AddForce(Vector2.right * -1, ForceMode2D.Impulse);

            if (rigid.velocity.x < maxSpeed * (-1))
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    void PlayerLanding()
    {
        if (rigid.velocity.y < 0)
        {
            GetComponent<CapsuleCollider2D>().isTrigger = false;
            float i;
            for (i = -0.4f; i <= 0.8; i = i + 0.4f)
            {
                Vector2 velocityVec = new Vector2(rigid.position.x + i, rigid.position.y);
                Debug.DrawRay(velocityVec, new Vector3(0, -1, 0), new Color(0, 1, 0, 255));
                RaycastHit2D rayHit = Physics2D.Raycast(velocityVec, new Vector3(0, -1, 0), 1, LayerMask.GetMask("PlatformColider", "Monster", "Block"));
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            OnDamaged(collision.transform.position);
        }
    }
    void OnDamaged(Vector2 targetPos)
    {
        hp = hp - 1;

        gameObject.layer = 9;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 5, ForceMode2D.Impulse);
        anim.SetTrigger("isDamaged");

        Invoke("OffDamaged", 1);
    }

    void OffDamaged()
    {
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void LeftDown()
    {
        inputLeft = true;
    }
    public void LeftUp()
    {
        inputLeft = false;
    }
    public void RightDown()
    {
        inputRight = true;
    }
    public void RightUp()
    {
        inputRight = false;
    }
    public void JumpDown()
    {
        inputJump = true;
    }
    public void JumpUp()
    {
        inputJump = false;
    }
    public void AttackDown()
    {
        if (EItem_Gun == true)
        inputAttack = true;
    }
    public void AttackUp()
    {
        inputAttack = false;
    }
}

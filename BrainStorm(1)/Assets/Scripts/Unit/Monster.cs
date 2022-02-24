using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public int maxHp;
    public int timer;
    public bool isDead;

    public int MonsterScore;
    public int nextMove;

    void OnEnable()
    {
        hp = maxHp;
        timer = 0;
        isDead = false;

        spriteRenderer.color = new Color(1, 1, 1, 1);
        spriteRenderer.flipY = false;
        capsuleCollider.enabled = true;
    }

    void Update()
    {
        MosterDie();
        timer = timer +1;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigid.velocity = new Vector2(nextMove * maxSpeed, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0, 255));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("PlatformColider"));
        if (isDead == false & rayHit.collider == null)
        {
            Turn();
        }
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
    }

    void MosterDie()
    {
        if (hp <= 0 & isDead == false)
        {
            isDead = true;
            gameManager.stageScore = gameManager.stageScore + MonsterScore;
            uiManager.StageScore();

            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            spriteRenderer.flipY = true;
            capsuleCollider.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            timer = 0;
        }

        /*if (isDead = true & timer >= 200)
        {
            gameObject.SetActive(false);
        }
        */
    }
}

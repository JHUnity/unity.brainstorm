using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            hp = hp - 1;
            if (hp >= 1)
            {
                anim.SetTrigger("isDamaged");
            }
        }

    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove * maxSpeed * 10, rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 0, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("PlatformColider"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
    }
}

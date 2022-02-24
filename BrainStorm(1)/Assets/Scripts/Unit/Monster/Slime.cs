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
}

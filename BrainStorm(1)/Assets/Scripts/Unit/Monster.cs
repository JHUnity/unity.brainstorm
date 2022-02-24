using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public int MonsterScore;
    public int nextMove;

    void Update()
    {
        DestroyMoster();
    }

    public void DestroyMoster()
    {
        if (hp <= 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.75f);
            spriteRenderer.flipY = true;
            capsuleCollider.enabled = false;
            rigid.AddForce(Vector2.up, ForceMode2D.Impulse);

            gameManager.stageScore = gameManager.stageScore + MonsterScore; gameObject.SetActive(false);
        }
    }
}

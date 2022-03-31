using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public int hp;
    public int maxHp;

    public int MonsterScore;
    public int nextMove;

    void OnEnable()
    {
        hp = maxHp;

        spriteRenderer.color = new Color(1, 1, 1, 1);
        spriteRenderer.flipY = false;
        capsuleCollider.enabled = true;
    }

    public void MosterDie()
    {
        GameManager.Instance.stageScore = GameManager.Instance.stageScore + MonsterScore;
        uiManager.StageScore();

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        capsuleCollider.enabled = false;
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        Invoke("Destroy", 1);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EItem_Gun : EItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiManager.EItem_1();
            uiManager.AttackButton.SetActive(true);
            player.EItem_Gun = true;
            ItemAddScore();
            DestroyItem();
        }
       
    }
}

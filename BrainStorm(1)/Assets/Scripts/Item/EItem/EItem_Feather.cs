using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EItem_Feather : EItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            uiManager.EItem_2();
            player.maxSpeed = 10;
            player.jumpPower = 22;
            ItemAddScore();
            DestroyItem();
        }
       
    }
}

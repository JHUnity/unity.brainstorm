using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SItem_Key2 : SItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.itemActive == 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                SitemGet();
                gameManager.SitemNumber = 2;
                DestroyItem();
            }
        }
    }
}

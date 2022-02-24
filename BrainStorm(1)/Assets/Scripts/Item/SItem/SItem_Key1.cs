using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SItem_Key1 : SItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameManager.itemActive == 0)
            {
                SitemGet();
                gameManager.SitemNumber = 1;
                DestroyItem();
            }
        }
    }
}

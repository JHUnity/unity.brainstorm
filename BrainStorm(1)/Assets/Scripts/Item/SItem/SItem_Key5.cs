using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SItem_Key5 : SItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.itemActive == 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                SitemGet();
                GameManager.Instance.SitemNumber = 5;
                DestroyItem();
            }
        }
    }
}

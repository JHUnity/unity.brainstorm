using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SItem_Key1 : SItem
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.Instance.itemActive == 0)
            {
                SitemGet();
                GameManager.Instance.SitemNumber = 1;
                DestroyItem();
            }
        }
    }
}

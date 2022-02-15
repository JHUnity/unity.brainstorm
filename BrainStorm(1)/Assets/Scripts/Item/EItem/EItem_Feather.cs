using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EItem_Feather : EItem
{
    public Player player;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.maxSpeed = 12;
        }
        base.OnTriggerEnter2D(collision);
    }
}

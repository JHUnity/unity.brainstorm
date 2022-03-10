﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SItem : Item
{
    public void SitemGet()
    {
        GameManager.Instance.itemActive = 30;

        Vector3 spotPos = gameObject.transform.position;
        player.itemDrop.position = spotPos;

        SItemChange();
    }

    public void SItemChange()
    {
        if (GameManager.Instance.SitemNumber == 1)
        {
            GameObject SItem_Key1 = objManager.MakeObj("SItem_Key1");
            SItem_Key1.transform.position = player.itemDrop.position;
        }

        if (GameManager.Instance.SitemNumber == 2)
        {
            GameObject SItem_Key2 = objManager.MakeObj("SItem_Key2");
            SItem_Key2.transform.position = player.itemDrop.position;
        }
    }
}

using System.Collections;
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

        if (GameManager.Instance.SitemNumber == 3)
        {
            GameObject SItem_Key3 = objManager.MakeObj("SItem_Key3");
            SItem_Key3.transform.position = player.itemDrop.position;
        }

        if (GameManager.Instance.SitemNumber == 4)
        {
            GameObject SItem_Key4 = objManager.MakeObj("SItem_Key4");
            SItem_Key4.transform.position = player.itemDrop.position;
        }

        if (GameManager.Instance.SitemNumber == 5)
        {
            GameObject SItem_Key5 = objManager.MakeObj("SItem_Key5");
            SItem_Key5.transform.position = player.itemDrop.position;
        }

        if (GameManager.Instance.SitemNumber == 6)
        {
            GameObject SItem_Key6 = objManager.MakeObj("SItem_Key6");
            SItem_Key6.transform.position = player.itemDrop.position;
        }

        if (GameManager.Instance.SitemNumber == 7)
        {
            GameObject SItem_Key7 = objManager.MakeObj("SItem_Key7");
            SItem_Key7.transform.position = player.itemDrop.position;
        }

        if (GameManager.Instance.SitemNumber == 11)
        {
            GameObject SItem_Shoes = objManager.MakeObj("SItem_Shoes");
            SItem_Shoes.transform.position = player.itemDrop.position;
        }
    }
}

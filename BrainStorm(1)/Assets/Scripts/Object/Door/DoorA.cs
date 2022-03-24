﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorA : Door
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.doorOpen[doorKeyNum-1] == false)
            {
                if (GameManager.Instance.SitemNumber == doorKeyNum)
                {
                    GameManager.Instance.SitemNumber = 0;
                    GameManager.Instance.stageScore = GameManager.Instance.stageScore + 500;

                    doorclosed.SetActive(false);
                    dooropen.SetActive(true);

                    player.doorOpen[doorKeyNum - 1] = true;
                }
            }
            if (player.doorOpen[doorKeyNum - 1] == true)
            {
                if (GameManager.Instance.doorActive == 0)
                {
                    player.transform.position = door2.position;
                }
                GameManager.Instance.doorActive = 30;
            }
        }
    }
}

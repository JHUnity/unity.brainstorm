using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;
    public ObjectManager objManager;
    public UIManager uiManager;

    public void DestroyItem()
    {
        gameObject.SetActive(false);
    }
}

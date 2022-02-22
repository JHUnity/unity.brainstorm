using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyBulletTime;

    void OnEnable()
    {
        Invoke("DestroyBullet", destroyBulletTime);
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletlifeSpan = 3;

    void Awake()
    {
        Destroy(gameObject, BulletlifeSpan);
    }
}

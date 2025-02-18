using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The life span of the bullet
    public float BulletlifeSpan = 3;


    void Awake()
    {
        Destroy(gameObject, BulletlifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
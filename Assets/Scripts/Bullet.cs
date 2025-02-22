using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the behavior for bullets for the gun prefab.
 * It creates a bullet lifespan, which ensures the bullet will
 * despawn after traveling a given distance. It also will destroy the
 * bullet when it collides with an object.
*/
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
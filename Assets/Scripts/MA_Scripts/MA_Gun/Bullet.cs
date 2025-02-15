using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The life span of the bullet
    public float BulletlifeSpan = 3;
    public int Damage = 25;

    void Awake()
    {
        Destroy(gameObject, BulletlifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            E_Health enemyHealth = collision.gameObject.GetComponent<E_Health>();
            if (enemyHealth != null)
            {
                enemyHealth.DamageOnEnemy(Damage);
            }
        }

        Destroy(gameObject);
    }

}

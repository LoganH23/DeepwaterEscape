using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Health : MonoBehaviour
{
    public int EnemyHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageOnEnemy(int damage)
    {
        EnemyHealth -= damage; 
        if (EnemyHealth <= 0) 
        {
            defeat();
        }
    }

    public void defeat()
    {
        Destroy(gameObject);
    }
}

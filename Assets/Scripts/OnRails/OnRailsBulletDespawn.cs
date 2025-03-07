using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRailsBulletDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyBullet()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}

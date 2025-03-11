using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRailsShooting : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;

    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletInst = Instantiate(bullet, new Vector3(bulletSpawn.position.x, bulletSpawn.position.y + 2, bulletSpawn.position.z), bulletSpawn.rotation);
            bulletInst.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            
        }
    }

}

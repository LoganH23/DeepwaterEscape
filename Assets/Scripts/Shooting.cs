using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the shooting mechanic used for the gun prefab.
 * On a mouse click, it spawns a bullet and gives it a forward velocity based
 * on a user-set speed. The gun has a cooldown time between which bullets
 * cannot be shot
*/
public class Shooting : MonoBehaviour
{
    //variables
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float bulletSpeed = 20;
    public float shootingDelay = 2f; // delay when firing
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        //check to see if gun shot
        if (Input.GetMouseButton(0) && canShoot)
        {
            Shoot();
        }
    }

    //create a bullet, move it then call cooldown
    void Shoot()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * bulletSpeed;
        StartCoroutine(ShootingCooldown());
    }

    //gun cooldown
    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
    }
}
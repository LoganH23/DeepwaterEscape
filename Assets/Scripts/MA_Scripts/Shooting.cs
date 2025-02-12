using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float bulletSpeed = 10;
    public float shootingDelay = 2f; // delay when firing
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * bulletSpeed;
        StartCoroutine(ShootingCooldown());
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
    }
}

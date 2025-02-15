using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Gun shoot and speed
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float bulletSpeed = 20;
    public float shootingDelay = 2f; // delay when firing
    private bool canShoot = true;

    // Ammo and Reload 
    public int maxAmmo = 20;
    public int currentAmmo;
    public float reloadTime = 2f;
    public bool isreload = false;

    // camera Zoom
    public Camera playerC;
    public float zoom = 10f;
    private float normalZoom;

    void Start()
    {
        currentAmmo = maxAmmo;
        normalZoom = playerC.fieldOfView;
    }
    // Update is called once per frame
    void Update()
    {
        if (isreload) return;

        // To shoot 
        if (Input.GetMouseButton(0) && canShoot && currentAmmo > 0)
        {
            Shoot();
        }

        // If out then no more bullet
        else if (Input.GetMouseButton(0) && canShoot && currentAmmo <= 0)
        {
            Debug.Log("Out of ammo");
        }

        // if R is press to reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        // The Right mouse to zoom the camera
        if (Input.GetMouseButtonDown(1))
        {
            playerC.fieldOfView = zoom;
        }

        else if (Input.GetMouseButtonUp(1))
        {
            playerC.fieldOfView = normalZoom;
        }

    }
    void Shoot()
    {
        // it move to where the player is facing
        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);

        // This the firerate
        bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * bulletSpeed;

        currentAmmo--;
        // it the cooldown to shoot
        StartCoroutine(ShootingCooldown());
    }

    IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
    }
    // make reload and amount of ammo

    IEnumerator Reload()
    {
        isreload = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isreload = false;
        Debug.Log("Reloaded");

    }
  

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This script handles the shooting mechanic used for the gun prefab.
 * On a mouse click, it spawns a bullet and gives it a forward velocity based
 * on a user-set speed. The gun has a cooldown time between which bullets
 * cannot be shot
*/

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

    public TextMeshProUGUI Ammotext;

    // camera Zoom
    public Camera playerC;
    public float zoom = 10f;
    private float normalZoom;
    private float duration = 0.5f;
    private float lerp = 0f;


    void Start()
    {
        currentAmmo = maxAmmo;
        normalZoom = playerC.fieldOfView;

        updateText();
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
        if (Input.GetMouseButton(1))
        {
            lerp = 0f;


            lerp += Time.deltaTime / duration;
            playerC.fieldOfView = Mathf.Lerp(playerC.fieldOfView, zoom, lerp);
        }
        else
        {
            lerp = 0f;

            lerp += Time.deltaTime / duration;
            playerC.fieldOfView = Mathf.Lerp(playerC.fieldOfView, normalZoom, lerp);
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

        updateText();
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
        updateText();

        isreload = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isreload = false;
        Debug.Log("Reloaded");
        updateText();
    }

    // ui to show ammo and how to reload
    void updateText()
    {
        Ammotext.text = "Ammo: " + currentAmmo + " / " + maxAmmo;

        if (currentAmmo == 0)
        {
            Ammotext.text = "Press R to reload ";

            if (Input.GetKeyDown(KeyCode.R))
            {
                Ammotext.text = "Reloading";
            }
        }
    }
}
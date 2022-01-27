using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //These are the stats for the player's shots
    [SerializeField] float shotSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] int shotDamage;
    [SerializeField] float shotCooldown;
    GameObject currentShot;
    bool canShoot = true;

    ScreenShake camera;

    //These are the stats for the player's missiles
    [SerializeField] float missileSpeed;
    [SerializeField] GameObject missile;
    [SerializeField] int missileDamage;
    [SerializeField] float missileCooldown;
    GameObject currentMissile;
    bool canMissile = true;

    [SerializeField] Vector2 shotOffset;
    Vector2 shotLocation;


    private void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<ScreenShake>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
            canShoot = false;
        }

        if (Input.GetButton("Fire2") && canMissile)
        {
            Missile();
            canMissile = false;
        }


    }

    private void Shoot()
    {
        shotLocation = new Vector2(transform.position.x + shotOffset.x, transform.position.y - shotOffset.y);
        currentShot = Instantiate(bullet, shotLocation, Quaternion.identity);
        currentShot.GetComponent<PlayerProjectile>().speed = shotSpeed;
        currentShot.GetComponent<PlayerProjectile>().damage = shotDamage;
        StartCoroutine(ShotCooldown());
    }

    private void Missile()
    {
        camera.ScreenShakeSmall();
        shotLocation = new Vector2(transform.position.x + shotOffset.x, transform.position.y - shotOffset.y);
        currentMissile = Instantiate(missile, shotLocation, Quaternion.identity);
        currentMissile.GetComponent<PlayerProjectile>().speed = missileSpeed;
        currentMissile.GetComponent<PlayerProjectile>().damage = missileDamage;
        StartCoroutine(MissileCooldown());
    }

    private IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }

    private IEnumerator MissileCooldown()
    {
        yield return new WaitForSeconds(missileCooldown);
        canMissile = true;
    }

}

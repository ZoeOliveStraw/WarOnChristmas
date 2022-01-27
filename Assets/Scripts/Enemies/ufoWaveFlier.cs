using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoWaveFlier : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Transform player;

    [SerializeField] GameObject shot;
    [SerializeField] float shotSpeed;
    [SerializeField] int shotDamage;
    [SerializeField] int damage;
    [SerializeField] Vector2 delayConstraints;
    [SerializeField] Vector2 nextShotLocation;

    [SerializeField] float hangTime;
    [SerializeField] float verticalMoveTime;
    [SerializeField] float verticalSpeed;

    [SerializeField] GameObject explosion;

    float currentVerticalSpeed;

    [SerializeField] int ufoHealth;

    [SerializeField] int pointValue;
    [SerializeField] int multiplierValue;

    private float yPosAtStart;
    private bool movingUp = true;

    GameObject currentShot;

    float shotDelay;
    bool canShoot = true;


    void Start()
    {
        yPosAtStart = transform.position.y;
        currentVerticalSpeed = verticalSpeed;
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        Move();
        if (canShoot == true)
        {
            Shoot();
            canShoot = false;
        }

        if (transform.position.x <= -2)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y + currentVerticalSpeed * Time.deltaTime);
    }

    private IEnumerator ChangeDirection()
    {
        bool moving = true;
        while (moving = true)
        {
            currentVerticalSpeed = 0;
            yield return new WaitForSeconds(hangTime);
            currentVerticalSpeed = (movingUp ? verticalSpeed : -verticalSpeed);
            movingUp = !movingUp;
            yield return new WaitForSeconds(verticalMoveTime);
        }
    }

    private void Shoot()
    {
        nextShotLocation = new Vector2(transform.position.x - 1, transform.position.y);
        currentShot = Instantiate(shot, nextShotLocation, Quaternion.identity);
        currentShot.GetComponent<ufoProjectile>().speed = shotSpeed;
        currentShot.GetComponent<ufoProjectile>().damage = shotDamage;
        StartCoroutine(ShotCooldown());
    }

    private IEnumerator ShotCooldown()
    {
        shotDelay = Random.Range(delayConstraints.x, delayConstraints.y);
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShot")
        {
            HandleHit(collision.gameObject.GetComponent<PlayerProjectile>().damage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HandleHit(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void HandleHit(int playerShot)
    {
        
        ufoHealth -= playerShot;
        if (ufoHealth <= 0)
        {
            GameObject.Find("Camera").GetComponent<ScreenShake>().ScreenShakeMedium();
            PlayerScore player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
            player.AddScore(pointValue, multiplierValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            GameObject.Find("Camera").GetComponent<ScreenShake>().ScreenShakeSmall();
        }
    }
}

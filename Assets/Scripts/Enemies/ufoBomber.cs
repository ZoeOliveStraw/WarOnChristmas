using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoBomber : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] int bombDamage;
    [SerializeField] int damage;
    [SerializeField] int health;
    [SerializeField] float bombFrequency;
    [SerializeField] GameObject explosion;

    [SerializeField] int pointValue;
    [SerializeField] int multiplierValue;

    private bool canBomb = false;

    GameObject currentBomb;

    Vector2 nextBombLocation;

    [SerializeField] GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, 8);
        StartCoroutine(BombCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (canBomb)
        {
            Bomb();
            canBomb = false;
        }

        if (transform.position.x <= -2)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void Bomb()
    {
        nextBombLocation = new Vector2(transform.position.x, transform.position.y - 1);
        currentBomb = Instantiate(bomb, nextBombLocation, Quaternion.identity);
        currentBomb.GetComponent<ufoBombScript>().speed = speed;
        currentBomb.GetComponent<ufoBombScript>().xSpeed = speed;
        currentBomb.GetComponent<ufoBombScript>().damage = bombDamage;
        StartCoroutine(BombCooldown());
    }

    private IEnumerator BombCooldown()
    {
        yield return new WaitForSeconds(bombFrequency);
        canBomb = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShot")
        {
            HandleHit(collision.gameObject.GetComponent<PlayerProjectile>().damage);
        }
        else if(collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerHealth>().HandleHit(damage);
            Destroy(gameObject);
        }
    }

    private void HandleHit(int playerShot)
    {
        health -= playerShot;
        if (health <= 0)
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

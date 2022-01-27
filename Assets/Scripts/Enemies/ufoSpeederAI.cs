using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoSpeederAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int health;
    [SerializeField] int damage;

    [SerializeField] int pointValue;
    [SerializeField] int multiplierValue;

    [SerializeField] GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -2)
        {
            Destroy(gameObject);
        }
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

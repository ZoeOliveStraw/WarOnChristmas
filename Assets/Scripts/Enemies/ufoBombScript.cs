using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoBombScript : MonoBehaviour
{
    
    public float speed;
    public float xSpeed;
    public int damage;

    [SerializeField] GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - xSpeed * Time.deltaTime, transform.position.y - speed * Time.deltaTime);

        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HandleHit(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }



}

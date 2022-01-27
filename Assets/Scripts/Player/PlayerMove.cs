using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float ySpeed;
    [SerializeField] float xSpeed;

    [SerializeField] Vector2 minConstraints;
    [SerializeField] Vector2 maxConstraints;

    [SerializeField] float pitchAmount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        OutOfBoundsCheck();
        PitchPlayer();
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x + 
            (xSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal")),
            transform.position.y + (xSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical")));
    }

    private void OutOfBoundsCheck()
    {
        if(transform.position.x > maxConstraints.x)
        {
            transform.position = new Vector2(maxConstraints.x, transform.position.y);
        }
        else if(transform.position.x < minConstraints.x)
        {
            transform.position = new Vector2(minConstraints.x, transform.position.y);
        }

        if (transform.position.y > maxConstraints.y)
        {
            transform.position = new Vector2(transform.position.x, maxConstraints.y);
        }
        else if (transform.position.y < minConstraints.y)
        {
            transform.position = new Vector2(transform.position.x, minConstraints.y);
        }
    }

    private void PitchPlayer()
    {
        if(Input.GetAxisRaw("Vertical") == 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, Quaternion.identity.w);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, pitchAmount * Input.GetAxis("Vertical"));
        }
        

    }

}

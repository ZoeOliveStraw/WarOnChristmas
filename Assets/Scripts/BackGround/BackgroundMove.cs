﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        if(transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSprite : MonoBehaviour
{

    SpriteRenderer sr;
    [SerializeField] Sprite[] clouds;
    int cloudIndex;

    [SerializeField] float depth;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cloudIndex = clouds.Length;
        sr.sprite = clouds[Random.Range(0,cloudIndex)];
        transform.position = new Vector3(transform.position.x, transform.position.y, depth);
    }
}

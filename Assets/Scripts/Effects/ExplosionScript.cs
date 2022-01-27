using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] float length;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        //animator.Play("ExplosionSmall");
        yield return new WaitForSeconds(length);
        Destroy(gameObject);
    }
}

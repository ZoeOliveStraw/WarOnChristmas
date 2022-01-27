using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    [SerializeField] GameObject tree;
    [SerializeField] Vector2 delay;
    [SerializeField] Vector2 yRange;

    Vector2 nextTreeLocation;

    bool spawnTree = true;

    private void Update()
    {
        if(spawnTree == true)
        {
            SpawnTree();
            spawnTree = false;
        }
    }

    private void SpawnTree()
    {
        nextTreeLocation = new Vector2(transform.position.x, Random.Range(yRange.x, yRange.y));
        Instantiate(tree, nextTreeLocation, Quaternion.identity);
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(delay.x, delay.y));
        spawnTree = true;
    }

}

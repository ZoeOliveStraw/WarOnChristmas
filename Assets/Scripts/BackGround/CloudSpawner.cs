using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    [SerializeField] Vector2 yConstraints;
    [SerializeField] Vector2 delay;
    Vector2 nextSpawnLocation;

    bool spawnCloud = true;


    void Update()
    {
        if(spawnCloud == true)
        {
            SpawnCloud();
            spawnCloud = false;
        }
    }

    private void SpawnCloud()
    {
        nextSpawnLocation = new Vector2(transform.position.x, Random.Range(yConstraints.x, yConstraints.y));
        Instantiate(cloud, nextSpawnLocation, Quaternion.identity);
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(delay.x, delay.y));
        spawnCloud = true;
    }
}

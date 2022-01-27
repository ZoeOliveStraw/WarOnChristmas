using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Vector2 spawnYRange;
    Vector2 nextSpawnPosition;
    Vector2 spawnDelayRange;
    GameObject nextEnemy;
    float nextDelay;
    WaveBuilder waveBuilder;
    Wave currentWave;

    // Start is called before the first frame update
    void OnEnable()
    {
        waveBuilder = GetComponent<WaveBuilder>();
        GetCurrentWave();
        SpawnEnemy();
    }

    // Update is called once per frame
    private void SpawnEnemy()
    {
        if(!this.enabled)
        {
            return;
        }
        nextDelay = currentWave.GetNextDelay();
        StartCoroutine(SpawnDelay());
        nextEnemy = currentWave.GetRandomEnemy();
        Debug.Log("Spwaning enemy");
        nextSpawnPosition = new Vector2(transform.position.x, Random.Range(spawnYRange.x, spawnYRange.y));
        Instantiate(nextEnemy, nextSpawnPosition, Quaternion.identity);
    }

    private void GetCurrentWave()
    {
        currentWave = null;
        currentWave = waveBuilder.GenerateWave();
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(nextDelay);
        SpawnEnemy();
    }

    public float CurrentWaveLength()
    {
        return currentWave.GetLength();
    }
}

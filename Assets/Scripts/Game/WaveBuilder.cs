using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBuilder : MonoBehaviour
{
    [SerializeField] public GameObject[] enemies;
    [SerializeField] Vector2 delayRange;
    [SerializeField] int numOfEnemies;
    [SerializeField] float lengthOfWave;
    [SerializeField] Wave wavePrefab;

    public GameObject RandomEnemy()
    {
        int enemyIndex = enemies.Length;
        return enemies[Random.Range(0, enemyIndex)];
    }


    public Wave GenerateWave()
    {
        Wave newWave = Instantiate(wavePrefab, transform.position,Quaternion.identity);
        newWave.SetWave(delayRange,lengthOfWave);
        for(int i = 0; i < numOfEnemies;i++)
        {
            newWave.AddEnemy(RandomEnemy());
        }
        return newWave;
    }
}

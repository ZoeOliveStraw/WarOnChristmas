using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float lengthOfWave;
    private Vector2 delayRange;
    private List<GameObject> myEnemies = new List<GameObject>();

    public void SetWave(Vector2 setDelay, float setLength)
    {
        delayRange = setDelay;
        lengthOfWave = setLength;
    }

    public float GetRandomDelay()
    {
        return Random.Range(delayRange.x, delayRange.y);
    }

    public GameObject GetRandomEnemy()
    {
        return myEnemies[(Random.Range(0, myEnemies.Count))];
    }

    public void AddEnemy(GameObject enemyToAdd)
    {
        myEnemies.Add(enemyToAdd);
    }

    public float GetNextDelay()
    {
        return Random.Range(delayRange.x, delayRange.y);
    }

    public float GetLength()
    {
        return lengthOfWave;
    }
}

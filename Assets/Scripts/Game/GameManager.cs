using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//

public class GameManager : MonoBehaviour
{
    [SerializeField] DisplayText textOnScreen;
    [SerializeField] float delayAtStart;
    [SerializeField] float breakBetweenWaves;
    [SerializeField] string startMessage;
    [SerializeField] string nextWaveMessage;
    private int currentWave;
    private int difficulty;
    [SerializeField] [Range(1,100)] int startingDifficulty;

    EnemySpawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<EnemySpawner>();
        spawner.enabled = false;
        currentWave = 1;
        StartCoroutine(RunGame());
    }

    private IEnumerator RunGame()
    {
        Debug.Log("RunGame() called");
        textOnScreen.ShowText(startMessage, 5.0f);
        yield return new WaitForSeconds(5.0f);
        while(true)
        {
            textOnScreen.FlashText("WAVE " + currentWave, 3.0f, 0.3f);
            currentWave++;
            yield return new WaitForSeconds(delayAtStart);
            spawner.enabled = true;
            yield return new WaitForSeconds(spawner.CurrentWaveLength());
            spawner.enabled = false;
            yield return new WaitForSeconds(breakBetweenWaves);
        }
    }
}

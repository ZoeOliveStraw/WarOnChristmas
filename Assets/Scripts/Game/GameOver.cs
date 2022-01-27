using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] float fadeInTime;
    [SerializeField] float hangTime;
    CanvasGroup gameOverCanvasGroup;

    private void Start()
    {
        gameOverCanvasGroup = gameOverCanvas.GetComponent<CanvasGroup>();
    }

    public void GameOverMethod()
    {
        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        gameOverCanvasGroup.interactable = false;
        while (gameOverCanvasGroup.alpha < 1)
        {
            gameOverCanvasGroup.alpha += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime / fadeInTime);
        }
        yield return new WaitForSeconds(hangTime);
        SceneManager.LoadScene(2);
    }
}

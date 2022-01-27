using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] float fadeOutTime;
    [SerializeField] GameObject gameOverMenu;
    CanvasGroup menuCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvasGroup = gameOverMenu.GetComponent<CanvasGroup>();
    }

    public void RetryButton()
    {
        StartCoroutine(GoToScene(1));
    }

    public void MainMenuButton()
    {
        StartCoroutine(GoToScene(0));
    }

    private IEnumerator GoToScene(int goToScene)
    {
        menuCanvasGroup.interactable = false;
        while (menuCanvasGroup.alpha > 0)
        {
            menuCanvasGroup.alpha -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime / fadeOutTime);
        }
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(goToScene);
    }
}

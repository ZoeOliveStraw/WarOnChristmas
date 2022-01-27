using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] float fadeOutTime;
    [SerializeField] GameObject mainMenu;
    CanvasGroup menuCanvasGroup;

    // Start is called before the first frame update
    private void Start()
    {
        menuCanvasGroup = mainMenu.GetComponent<CanvasGroup>();
    }

    public void NewGame()
    {
        StartCoroutine(StartGameFadeOut());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator StartGameFadeOut()
    {
        menuCanvasGroup.interactable = false;
        while(menuCanvasGroup.alpha> 0)
        {
            menuCanvasGroup.alpha -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime / fadeOutTime);
        }
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(1);
    }
}

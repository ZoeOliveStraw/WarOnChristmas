using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth;
    int maxHealth;
    int currentHealth;
    Slider healthBar;

    ScreenShake camera;

    [SerializeField] GameObject explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = startingHealth;
        currentHealth = maxHealth;
        healthBar = GameObject.Find("Health Bar").GetComponent<Slider>();
        camera = GameObject.Find("Camera").GetComponent<ScreenShake>();
        RenderHealth();
    }

    private void RenderHealth()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void HandleHit(int damage)
    {
        currentHealth -= damage;
        RenderHealth();
        if(currentHealth <= 0)
        {
            camera.ScreenShakeLarge();
            PlayerDeath();
        }
        else
        {
            camera.ScreenShakeMedium();
        }
        gameObject.GetComponent<PlayerScore>().ResetMultiplier();
    }

    private void PlayerDeath()
    {
        GameObject.Find("Game Over").GetComponent<GameOver>().GameOverMethod();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

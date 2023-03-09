using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void OnEnable()
    {
        Health.GameOver += EnableGameOverDeath;
    }

    private void OnDisable()
    {
        Health.GameOver -= EnableGameOverDeath;
    }

    public void EnableGameOverDeath()
    {
        gameOverScreen.SetActive(true);
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

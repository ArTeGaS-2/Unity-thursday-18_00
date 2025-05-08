using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pauseMenuObject; // Все вікно паузи

    private void Awake()
    {
        instance = this;
        pauseMenuObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true); // Активація вікна
        Time.timeScale = 0.0f; // Зупинка часу
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); // Деактивація вікно
        Time.timeScale = 1.0f; // Повернення часу
    }
}

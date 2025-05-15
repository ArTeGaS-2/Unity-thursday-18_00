using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance; // Один екземпляр
    public GameObject pauseMenuObject; // Все вікно паузи
    public GameObject inGamePauseButtonObject; // Кнопка в куті

    private bool isPaused = false;

    private void Awake()
    {
        instance = this; // Прив'зуємо існуюче вікно до змінної
        pauseMenuObject.SetActive(false); // Вимикаємо вікно на початку
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) // Якщо натиснуто ESC
            && !isPaused) // Перевіряємо що пауза не активна 
        {
            OpenPauseMenu(); // Віткриваємо вікно паузи
        }
        else if (Input.GetKeyDown(KeyCode.Escape) // Якщо натиснуто ESC
                && isPaused) // Перевіряємо що пауза активна 
        {
            ClosePauseMenu(); // Закриваємо вікно паузи
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0); // Завантаження сцени меню (уточніть ID 1 або 0 )
        Time.timeScale = 1.0f; // Відновлення ігрового часу
    }
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true); // Активація вікна
        Time.timeScale = 0.0f; // Зупинка часу
        isPaused = true; // Змінюємо стан індикаора на активний
        inGamePauseButtonObject.SetActive(false);
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); // Деактивація вікно
        Time.timeScale = 1.0f; // Повернення часу
        isPaused = false; // Змінюємо стан індикаора на не активний
        inGamePauseButtonObject.SetActive(true);
    }
}

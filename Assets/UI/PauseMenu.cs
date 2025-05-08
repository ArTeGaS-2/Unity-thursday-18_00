using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pauseMenuObject; // ��� ���� �����

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
        pauseMenuObject.SetActive(true); // ��������� ����
        Time.timeScale = 0.0f; // ������� ����
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); // ����������� ����
        Time.timeScale = 1.0f; // ���������� ����
    }
}

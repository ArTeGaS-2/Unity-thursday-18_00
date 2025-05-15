using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance; // ���� ���������
    public GameObject pauseMenuObject; // ��� ���� �����
    public GameObject inGamePauseButtonObject; // ������ � ���

    private bool isPaused = false;

    private void Awake()
    {
        instance = this; // ����'���� ������� ���� �� �����
        pauseMenuObject.SetActive(false); // �������� ���� �� �������
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) // ���� ��������� ESC
            && !isPaused) // ���������� �� ����� �� ������� 
        {
            OpenPauseMenu(); // ³�������� ���� �����
        }
        else if (Input.GetKeyDown(KeyCode.Escape) // ���� ��������� ESC
                && isPaused) // ���������� �� ����� ������� 
        {
            ClosePauseMenu(); // ��������� ���� �����
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0); // ������������ ����� ���� (������� ID 1 ��� 0 )
        Time.timeScale = 1.0f; // ³��������� �������� ����
    }
    public void OpenPauseMenu()
    {
        pauseMenuObject.SetActive(true); // ��������� ����
        Time.timeScale = 0.0f; // ������� ����
        isPaused = true; // ������� ���� ��������� �� ��������
        inGamePauseButtonObject.SetActive(false);
    }
    public void ClosePauseMenu()
    {
        pauseMenuObject.SetActive(false); // ����������� ����
        Time.timeScale = 1.0f; // ���������� ����
        isPaused = false; // ������� ���� ��������� �� �� ��������
        inGamePauseButtonObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerObj : MonoBehaviour
{
    // ���������� �����, �������� �������� ��'����
    private void OnCollisionEnter(Collision collision)
    {
        // ��������, ��� � ��'���� ��� ��� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}

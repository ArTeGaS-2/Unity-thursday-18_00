using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerObj : MonoBehaviour
{
    // Вбудований метод, перевіряє зіткнення об'єктів
    private void OnCollisionEnter(Collision collision)
    {
        // Перевіряє, щоб у об'єкта був тег "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}

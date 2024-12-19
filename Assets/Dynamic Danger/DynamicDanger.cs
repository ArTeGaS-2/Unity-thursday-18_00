using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Час/затримка до події
    public float enemySpeed = 5f; // Швидкість ворога/об'єкта
    private void Start()
    {
        StartCoroutine(rotateEnemy());
    }
    private IEnumerator rotateEnemy()
    {
        // Затримка перед початком роботи методу у needToGo(3) секунди
        yield return new WaitForSeconds(needToGo);
        // Обертання об'єкту
        transform.rotation = Quaternion.Euler(
            transform.rotation.x, // x
            90,                   // y
            90);                  // z
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Час/затримка до події
    public float enemySpeed = 5f; // Швидкість ворога/об'єкта

    // Змінні під кут обертання
    public float currentRotationX = 0f; // X
    public float currentRotationY = 0f; // Y
    public float currentRotationZ = 0f; // Z

    // Прискорення по осям
    public float currentSpeedX = 0f; // X
    public float currentSpeedY = 0f; // Y
    public float currentSpeedZ = 0f; // Z
    private void Start()
    {
        StartCoroutine(RotateEnemy());
    }
    private void Update()
    {
        // Зміна позиції
        transform.position = new Vector3(
            transform.position.x + currentSpeedX,
            transform.position.y + currentSpeedY,
            transform.position.z + currentSpeedZ);
    }
    private IEnumerator RotateEnemy()
    {
        while (true)
        {
            // Затримка перед початком роботи методу у needToGo(3) секунди
            yield return new WaitForSeconds(needToGo);
            // Обертання об'єкту
            transform.rotation = Quaternion.Euler(
                currentRotationX, // x
                currentRotationY, // y
                currentRotationZ);// z
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
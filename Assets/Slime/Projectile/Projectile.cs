using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Шаблон проджектайлу
    public float projectileSpeed = 10f; // Швидкість проджектайлу

    public Transform spawnPoint; // Точка появи(пустий об'єкт на сцені)

    public void ShootProjectileForward()
    {
        // Напрямок обираємо за орієнтацією персонажа.
        Vector3 direction = transform.forward;

        // Встановлюємо обертання для проджектайлу, щоб він "дивився" у напрямку руху
        Quaternion projectileRotation = Quaternion.LookRotation(direction);

        // Створення проджектайлу з заданою позицією і обертанням
        GameObject projectile = Instantiate(
            projectilePrefab,    // Об'єкт 
            spawnPoint.position, // Позиція
            projectileRotation); // Обертання

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if(rb != null) // Якщо фізичний компонент є на об'єкті
        {
            rb.velocity = direction * projectileSpeed; // Надає прискорення
        }
        Destroy(projectile,10f); // Знищує через 10 секунд
    }
}
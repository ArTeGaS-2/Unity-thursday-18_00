using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_spawner : MonoBehaviour
{
    // Список мікроорганізмів(або інших об'єктів) для спавну
    public List<GameObject> organisms;
    // Число організмів, які треба заспавнити
    public int spawnNumber = 10;
    // Радіус зони спавну
    public float radius = 5f;

    // Координати для спавну
    private float x_Pos;
    private float z_Pos;

    // Затримка між спавном
    public float delay = 0.2f;
    private void Start()
    {

        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    // Спавнить об'єкти з затримкою
    {
        while (true)
        {
            // Визначаємо позицію
            x_Pos = Random.Range(-radius, radius);
            z_Pos = Random.Range(-radius, radius);
            // Обираємо об'єкт зі списку
            GameObject objectToSpawn = organisms[
                Random.Range(0, organisms.Count)];
            // Створюємо змінну з координатами
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);
            // Спавнимо
            Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
            // Затримка в "delay" секунд
            yield return new WaitForSeconds(delay);
        }
    }
}

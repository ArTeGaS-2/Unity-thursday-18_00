using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
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
    private void Start()
    {
        // Повторює блок коду, допоки не виконана умова
        for (int i=0; // Призначаємо змінну "і" для умови
            i < spawnNumber; // Умова - поки "і" не дорівнює змінній "spawnNumber"
            i++) // Додає +1 до "i" після кожної ітерації(проходження по колу)
        {
            x_Pos = Random.Range(0, radius);
            z_Pos = Random.Range(0, radius);

            GameObject objectToSpawn = organisms[
                Random.Range(0, organisms.Count - 1)];

            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);

            Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
        }
    }
}

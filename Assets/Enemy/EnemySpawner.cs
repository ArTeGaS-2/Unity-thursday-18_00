using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ���������� ������ �� ���� X �� Z
    private float xSpawnDistance;
    private float zSpawnDistance;

    // �������� �� ��������� �������
    [SerializeField]private float spawnInterval = 5f;

    // ������� ������, ������� ��� ����������� ������
    private Transform playerTransform;

    // ��������� �� ������ ������
    [SerializeField]private GameObject enemyPrefab;

    private void Start()
    {
        playerTransform = GameObject.Find("Slime").
            GetComponent<Transform>();
        InvokeRepeating("SpawnEnemy", 2, spawnInterval);
    }
    private void SpawnEnemy()
    {
        // �������� �������
        Vector3 spawnPoint = playerTransform.position;

        // ���������� ���� �� ��� ��������� (X �� Z)
        int axisChoice = Random.Range(0, 2);

        switch (axisChoice)
        {
            case 0:
                zSpawnDistance = Random.Range(0f, 14.1f);
                xSpawnDistance = 20f;
                break;
            case 1:
                zSpawnDistance = 14f;
                xSpawnDistance = Random.Range(0f, 20.1f);
                break;
        }
        // ���������� ���� ��������
        int signChoice = Random.Range(0, 2);
        if (signChoice == 0)
        {
            spawnPoint.x += xSpawnDistance;
            spawnPoint.z += zSpawnDistance;
        }
        else
        {
            spawnPoint.x -= xSpawnDistance;
            spawnPoint.z -= zSpawnDistance;
        }
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }
}

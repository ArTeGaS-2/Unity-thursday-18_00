using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_spawner : MonoBehaviour
{
    // ������ ������������(��� ����� ��'����) ��� ������
    public List<GameObject> organisms;
    // ����� ��������, �� ����� ����������
    public int spawnNumber = 10;
    // ����� ���� ������
    public float radius = 5f;

    // ���������� ��� ������
    private float x_Pos;
    private float z_Pos;

    // �������� �� �������
    public float delay = 0.2f;
    private void Start()
    {

        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    // �������� ��'���� � ���������
    {
        while (true)
        {
            // ��������� �������
            x_Pos = Random.Range(-radius, radius);
            z_Pos = Random.Range(-radius, radius);
            // ������� ��'��� � ������
            GameObject objectToSpawn = organisms[
                Random.Range(0, organisms.Count)];
            // ��������� ����� � ������������
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);
            // ��������
            Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
            // �������� � "delay" ������
            yield return new WaitForSeconds(delay);
        }
    }
}

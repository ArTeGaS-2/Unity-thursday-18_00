using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_temp : MonoBehaviour
{
    // ������ ������������(��� ����� ��'����) ��� ������
    public List<GameObject> organisms;
    // ����� ��������, �� ����� ����������
    public int spawnNumber = 10;
    // ����� ���� ������
    public float radius = 5f;

    private float x_Pos;
    private float z_Pos;
    private void Start()
    {
        // �������� ���� ����, ������ �� �������� �����
        for (int i = 0; // ���������� ����� "�" ��� �����
            i < spawnNumber; // ����� - ���� "�" �� ������� ����� "spawnNumber"
            i++) // ���� +1 �� "i" ���� ����� ��������(����������� �� ����)
        {
            x_Pos = Random.Range(0, radius);
            z_Pos = Random.Range(0, radius);

            GameObject objectToSpawn = organisms[Random.Range(0, organisms.Count)];

            Vector3 spawnPoint = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);

            Instantiate(objectToSpawn, spawnPoint, objectToSpawn.transform.rotation);
        }
    }
}

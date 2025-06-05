using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DecoSpawner : MonoBehaviour
{
    // ������ ������������(��� ����� ��'����) ��� ������
    public List<GameObject> decors;

    public float distance = 1f; // ³������ �� �����������

    // ѳ��� � �������� �� X �� �� Y
    public int x_Num_Max = 10;
    public int z_Num_Max = 10;

    // ������� ����������
    public int x_Num = -10;
    public int z_Num = -10;
    private void Start()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(
                x_Pos,
                objectToSpawn.transform.position.y,
                z_Pos);
            Instantiate(decors[Random.Range(0, decors.Count - 1)]);

        }
    }
}
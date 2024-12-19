using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // ���/�������� �� ��䳿
    public float enemySpeed = 5f; // �������� ������/��'����
    private void Start()
    {
        StartCoroutine(rotateEnemy());
    }
    private IEnumerator rotateEnemy()
    {
        // �������� ����� �������� ������ ������ � needToGo(3) �������
        yield return new WaitForSeconds(needToGo);
        // ��������� ��'����
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

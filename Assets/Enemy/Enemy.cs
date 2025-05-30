using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Transform target; // ֳ�� ������ (�������� ������)
    private NavMeshAgent agent; // ��������� ������ AI Navigation
    private void Start()
    {
        if (GameObject.Find("Player"))
        {
            // ��������� ��������� ������ �� ���� � �������� �������
            target = GameObject.Find("Player").GetComponent<Transform>();
        }
        else if (GameObject.Find("Slime"))
        {
            // ��������� ��������� ������ �� ���� � �������� �������
            target = GameObject.Find("Slime").GetComponent<Transform>();
        }
        // �������� ��������� NavMeshAgent � ��'���� ������
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        // ��������, �� ���� ���������/ �������� ���� (�������)
        if (target != null)
        {
            // ���������� ���� ��� ��'���� ������
            agent.SetDestination(target.position);
        }
    }
    IEnumerator StopMoving()
    {
        // ������� ������ 
        agent.isStopped = true;
        // ���� 3 �������
        yield return new WaitForSeconds(3f);
        // ������� ��� ������
        agent.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Slime"))
        {
            SceneManager.LoadScene(1);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

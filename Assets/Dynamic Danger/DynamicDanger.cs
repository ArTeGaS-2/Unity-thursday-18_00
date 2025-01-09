using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // ���/�������� �� ��䳿
    public float objectSpeed = 5f; // �������� ������/��'����

    private Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = Vector3.forward *
                      objectSpeed *
                      Time.deltaTime;

    }
}
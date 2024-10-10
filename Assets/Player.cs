using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera; // ��������� �� ������
    public float maxSpeed = 10f; // ����������� ��������
    public float forceTime = 1f; // ��� 䳿 �������
    public float forceMultiplier = 100f; // ������� ��� ����

    private Rigidbody rb;

    private void Start()
    {
        // �������� ��������� �� ��������� Rigidbody � ��'����
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // �������� ������� ���� � ������� �����������
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // ��������� �������� �� ������� �� ����� �������
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0; // ��������

            // ��������� ������ � �������� �� �������
            if (direction.magnitude > 0.1f) // ��� �������� ������� ���������
            {
                // �������� �������� �� �������
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // ������ ������ �� ��������� ���� �� ���������
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 5f);
            }

            // ������ ��������� ��� ������� ���
            if (Input.GetMouseButton(0))
            {
                // �����������
                rb.AddForce(direction * forceMultiplier *
                    Time.deltaTime, ForceMode.Acceleration);
                // �������� ����������� ��������
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

                SlimeMoveAnim();
            }
            else
            {
                SlimeStopAnim();
            }
        }
        mainCamera.transform.position = new Vector3(
            transform.position.x,
            7,
            transform.position.z - 1);
    }
    private void SlimeMoveAnim()
    {
        transform.localScale = new Vector3(
            0.8f,
            transform.localScale.y,
            1.3f);
    }
    private void SlimeStopAnim()
    {
        transform.localScale = new Vector3(
            1f,
            transform.localScale.y,
            1f);
    }
}

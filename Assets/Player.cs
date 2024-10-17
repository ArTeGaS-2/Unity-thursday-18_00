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

    public float divider = 2f;

    private Vector3 scaleMod;
    private Vector3 currentScale;

    public float forwardMod = 1.3f; // ����������� �������
    public float sideMod = 0.8f; // ̳������� ������

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
    // ����� ������ � ������� �� ����
    private void SlimeMoveAnim()
    {
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1.3f,
            Time.deltaTime / 0.5f);

        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            0.8f,
            Time.deltaTime / 0.5f);

        transform.localScale = new Vector3(
            sideScale, // ���� ������
            transform.localScale.y, // ������ �� ���������
            forwardScale); // ���� �������
    }
    // ������� ��������� �������
    private void SlimeStopAnim()
    {
        float forwardScale = Mathf.Lerp(
            transform.localScale.z,
            1f,
            Time.deltaTime / 0.5f);

        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            1f,
            Time.deltaTime / 0.5f);

        transform.localScale = new Vector3(
            sideScale, // ���� ������
            transform.localScale.y, // ������ �� ���������
            forwardScale); // ���� �������
    }
}

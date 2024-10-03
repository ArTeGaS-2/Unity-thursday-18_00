using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera; // Посилання на камеру
    public float maxSpeed = 10f; // Максимальна швидкість
    public float forceTime = 1f; // Час дії інерції
    public float forceMultiplier = 100f; // Множник для сили

    private Rigidbody rb;

    private void Start()
    {
        // Отримуємо посилання на компонент Rigidbody з об'єкту
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Отримуємо позицію миші в світових координатах
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;

            // Визначаємо напрямок від слимака до точки курсора
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0; // Ігноруємо

            // Рухаємо персонажа при натиску ЛКМ
            if (Input.GetMouseButton(0))
            {
                // Прискорюємо
                rb.AddForce(direction * forceMultiplier *
                    Time.deltaTime, ForceMode.Acceleration);
                // Обмежуємо максимальну швидкість
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
    }
}

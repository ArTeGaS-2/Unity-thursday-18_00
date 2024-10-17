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

    public float divider = 2f;

    private Vector3 scaleMod;
    private Vector3 currentScale;

    public float forwardMod = 1.3f; // Максимальна довжина
    public float sideMod = 0.8f; // Мінімальна ширина

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

            // Повертаємо слайма у напрямку до курсору
            if (direction.magnitude > 0.1f) // Щоб уникнути дрібного коливання
            {
                // Отримуємо напрямок до курсору
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Плавно обиртає від поточного кута до цільового
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * 5f);
            }

            // Рухаємо персонажа при натиску ЛКМ
            if (Input.GetMouseButton(0))
            {
                // Прискорюємо
                rb.AddForce(direction * forceMultiplier *
                    Time.deltaTime, ForceMode.Acceleration);
                // Обмежуємо максимальну швидкість
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
    // Змінює ширину і довжину по кліку
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
            sideScale, // Зміна ширини
            transform.localScale.y, // Висота не змінюється
            forwardScale); // Зміна довжини
    }
    // Зупиняє виконання анімації
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
            sideScale, // Зміна ширини
            transform.localScale.y, // Висота не змінюється
            forwardScale); // Зміна довжини
    }
}

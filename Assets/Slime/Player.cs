using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Camera mainCamera; // Посилання на камеру
    private float cameraDistance = 7f;
    private float cameraDistanceMod;
    public float multiplier = 0.02f;

    public float maxSpeed = 10f; // Максимальна швидкість
    public float forceTime = 1f; // Час дії інерції
    public float forceMultiplier = 100f; // Множник для сили

    private Rigidbody rb;

    public float divider = 2f; // Ділитель

    private Vector3 scaleMod; // Модифікатор розміру
    private Vector3 currentScale; // Поточний розмір
    public float forwardMod = 1.3f; // Максимальна довжина
    public float sideMod = 0.8f; // Мінімальна ширина

    private void Start()
    {
        Instance = this;
        // Отримуємо посилання на компонент Rigidbody з об'єкту
        rb = GetComponent<Rigidbody>();
        
        currentScale = transform.localScale; // Додає данні про поточний розмір

        scaleMod = transform.localScale / divider;

        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;
    }
    public void AddScale()
    {
        currentScale = currentScale + scaleMod;

        forwardMod = currentScale.z * 1.3f;
        sideMod = currentScale.x * 0.8f;
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
            forwardMod,
            Time.deltaTime / 0.5f);

        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            sideMod,
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
            currentScale.z,
            Time.deltaTime / 0.5f);

        float sideScale = Mathf.Lerp(
            transform.localScale.x,
            currentScale.x,
            Time.deltaTime / 0.5f);

        transform.localScale = new Vector3(
            sideScale, // Зміна ширини
            transform.localScale.y, // Висота не змінюється
            forwardScale); // Зміна довжини
    }
}

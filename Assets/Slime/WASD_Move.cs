using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Move : MonoBehaviour
{
    public static WASD_Move Instance; // Сінглтон

    public Camera mainCamera; // Камера
    private static float cameraDistance = 7f; // Висота камери

    public float maxSpeed = 10f; // Швидкість
    public float rotationSpeed = 10f; // Швидкість обертання

    private Rigidbody rb; // Фізичний компонент
    public Animator animator; // Посилання на аніматор
    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }
}

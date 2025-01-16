using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3f; // Час/затримка до події
    public float objectSpeed = 5f; // Швидкість ворога/об'єкта

    private Rigidbody rb;

    private float currentAngleMod = 0f; // Поточний модифікатор напрямку
    public float anglePerIteration = 90f; // Зміна кута за ітерацію
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        rb.velocity = Vector3.left *
                      objectSpeed *
                      Time.deltaTime;

    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo); // затримка у секундах
                                                       // Зміна поточного кута

            Vector3 currenEulerAngles = transform.rotation.eulerAngles;

            currenEulerAngles.z += currentAngleMod;

            transform.rotation = Quaternion.Euler(currenEulerAngles);

            currentAngleMod += anglePerIteration; // Зміна значення модифікатора
        }
    }
}
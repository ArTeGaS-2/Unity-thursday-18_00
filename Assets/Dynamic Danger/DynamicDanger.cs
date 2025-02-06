using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicDanger : MonoBehaviour
{
    public float needToGo = 3.1f; // Час/затримка до події
    public float objectSpeed = 5f; // Швидкість ворога/об'єкта

    private Rigidbody rb;

    public float anglePerIteration = 90f; // Зміна кута за ітерацію
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RotateDynamicDanger());
    }
    private void Update()
    {
        Vector3 forward = transform.up;
        rb.velocity = forward *
                      objectSpeed *
                      Time.deltaTime;
    }
    private IEnumerator RotateDynamicDanger()
    {
        while (true)
        {
            yield return new WaitForSeconds(needToGo); // затримка у секундах
                                                       // Зміна поточного кута
            // Змінна поточного кута 
            Vector3 currenEulerAngles =
                transform.rotation.eulerAngles;
            // Додавання змін до координати y
            currenEulerAngles.y += anglePerIteration;
            // Встановлення нових координат обертання
            transform.rotation = Quaternion.Euler(currenEulerAngles);
        }
    }
}
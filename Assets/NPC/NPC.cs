using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Перевіряє чи миша над NPC
    private void OnMouseOver()
    {
        // Перевіряє, чи натиснута права кнопка миші
        if (Input.GetMouseButtonDown(1))
        {
            // Звітує в консоль, що кнопка натиснута
            Debug.Log("Інтеракція є");
        }
    }
}

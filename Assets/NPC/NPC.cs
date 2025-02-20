using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject gameShop;

    private void Start()
    {
        gameShop = GetComponent<GameObject>();
        gameShop.SetActive(false);
    }
    // Перевіряє чи миша над NPC
    private void OnMouseOver()
    {
        // Перевіряє, чи натиснута права кнопка миші
        if (Input.GetMouseButtonDown(1))
        {
            gameShop.SetActive(true);
        }
    }
}

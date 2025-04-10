using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Shop : MonoBehaviour
{
    Renderer slimeRenderer;

    public GameObject gameShop; // Посилання на об'єкт магазину
    private void Start()
    {
        if (slimeRenderer != null)
        {
            slimeRenderer = Player.Instance.gameObject.GetComponent<Renderer>();
        }
        gameShop.SetActive(false); // Вимикаємо рамку магазину
    }
    public void SetColorRed()
    {
        slimeRenderer.material.color = Color.red;
    }
    public void SetColorGreen()
    {
        slimeRenderer.material.color = Color.green;
    }
    public void SetColorBlue()
    {
        slimeRenderer.material.color = Color.blue;
    }
    public void CloseShop()
    {
        gameShop.SetActive(false);
    }
}

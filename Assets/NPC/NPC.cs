using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject gameShop;

    public Texture2D customCursor;
    // Перевіряє чи миша над NPC
    private void OnMouseOver()
    {
        // Перевіряє, чи натиснута права кнопка миші
        if (Input.GetMouseButtonDown(1))
        {
            gameShop.SetActive(true);
            Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}

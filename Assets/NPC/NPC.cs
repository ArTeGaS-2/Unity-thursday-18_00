using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject gameShop;

    public Texture2D customCursor;
    // �������� �� ���� ��� NPC
    private void OnMouseOver()
    {
        // ��������, �� ��������� ����� ������ ����
        if (Input.GetMouseButtonDown(1))
        {
            gameShop.SetActive(true);
            Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}

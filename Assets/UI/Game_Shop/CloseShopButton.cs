using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopButton : MonoBehaviour
{
    public Texture2D customCursor;

    public void OnMouseEnter_()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }
    public void OnMouseExit_()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

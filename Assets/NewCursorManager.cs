using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCursorManager : MonoBehaviour
{
    public Texture2D cursorTexture, cursorTexturePointer, cursorTextureI;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }


    public void SetMouseStandard()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void SetMousePointer()
    {
        Cursor.SetCursor(cursorTexturePointer, hotSpot, cursorMode);
    }

    public void SetMouseI()
    {
        Cursor.SetCursor(cursorTextureI, hotSpot, cursorMode);
    }
}

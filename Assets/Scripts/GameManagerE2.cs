using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerE2 : MonoBehaviour
{

    public int life = 2;
    public int numberOfRow = 100;

    public float bandSpeed = 1.0f;

    public bool isCollisionActive = true;
    public bool isGameRunning = true;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Texture2D cursorTexture, cursorTexture2;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitSound;

    public IEnumerator TempInactivity()
    {
        audioSource.PlayOneShot(hitSound);
        life = life - 1;
        Cursor.SetCursor(cursorTexture2, hotSpot, cursorMode);

        yield return new WaitForSeconds(1.0f);

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        isCollisionActive = true;
    }
}

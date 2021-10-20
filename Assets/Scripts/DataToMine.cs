using System.Collections;
using UnityEngine;

public class DataToMine : MonoBehaviour
{

    [SerializeField] private Texture2D cursorBaseTexture;
    [SerializeField] private Texture2D cursorAnimTexture;
    private Vector2 hotSpot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    [SerializeField] Transform[] waypoints;
    int waypointIndex = 0;
    [SerializeField] float moveSpeed = 2f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip breakSound;
    [SerializeField] AudioClip hitSound;

    private int lifePoints = 2;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Vector3 dir = waypoints[waypointIndex].position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.3f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }

    void OnMouseDown()
    {
        StartCoroutine("AnimationCursor");
        lifePoints -= 1;
        audioSource.PlayOneShot(hitSound);
        if(lifePoints == 0)
        {
            Cursor.SetCursor(cursorBaseTexture, hotSpot, cursorMode);
            audioSource.PlayOneShot(breakSound);
            Destroy(gameObject);
        }
    }

    IEnumerator AnimationCursor()
    {
        Cursor.SetCursor(cursorAnimTexture, hotSpot, cursorMode);
        yield return new WaitForSeconds(0.2f);
        Cursor.SetCursor(cursorBaseTexture, hotSpot, cursorMode);
    }
}

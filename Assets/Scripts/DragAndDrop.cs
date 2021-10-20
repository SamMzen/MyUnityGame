using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private int itemID;

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 initialPosition;

    public Texture2D cursorTexture, cursorTexturePointer, cursorTextureI;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexturePointer, hotSpot, cursorMode);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if(tag != "Clue")
        {
            transform.position = initialPosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexturePointer, hotSpot, cursorMode);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}

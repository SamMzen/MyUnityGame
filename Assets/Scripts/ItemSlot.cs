using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    [SerializeField] private string goodItemTag;

    [SerializeField] GameObject itemParent;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victorySound;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {

            if(eventData.pointerDrag.tag == goodItemTag)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.transform.SetParent(this.transform, true);
                Destroy(eventData.pointerDrag.GetComponent<DragAndDrop>());
                if(itemParent.transform.childCount == 6)
                {
                    audioSource.PlayOneShot(victorySound);
                }
            }
        }
    }
}

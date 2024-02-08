using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Image _image;
    private RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Bring the dragged object to the front
        transform.SetAsLastSibling();
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Set the object as the last sibling when clicked
        transform.SetAsLastSibling();
    }
}

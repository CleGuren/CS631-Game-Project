using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OverlayText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject overlayText;
    private bool hoverOver = false;
    public void Start()
    {
        overlayText.SetActive(false);
    }
    
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        overlayText.SetActive(true);
    }
    
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        overlayText.SetActive(false);
          
    }
}
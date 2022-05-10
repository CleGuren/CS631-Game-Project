using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignPostCollider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject overlayText;
    
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


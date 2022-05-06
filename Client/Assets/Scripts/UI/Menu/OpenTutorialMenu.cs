using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenTutorialMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tutorialMenu;
    
    public void Start()
    {
        tutorialMenu.SetActive(false);
    }
    
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tutorialMenu.SetActive(true);
    }
    
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tutorialMenu.SetActive(false);
         
    }
}

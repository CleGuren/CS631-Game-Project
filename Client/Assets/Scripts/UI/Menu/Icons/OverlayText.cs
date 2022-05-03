using System;
using UnityEngine;

public class OverlayText : MonoBehaviour
{
    public GameObject overlayText;
    public void Start()
    {
        overlayText.SetActive(false);
    }

    public void OnMouseOver()
    {
        overlayText.SetActive(true);
    }

    public void OnMouseExit()
    {
        overlayText.SetActive(false);
    }
    
    public interface IClickable
    {
        void OnClick();
    }
}
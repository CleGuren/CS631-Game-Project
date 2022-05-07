using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnKeyPressEscape : MonoBehaviour
{
    public GameObject panel;
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            panel.SetActive(false);
        }
    }
}

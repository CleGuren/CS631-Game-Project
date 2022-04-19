using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickInputSystem : MonoBehaviour
{
    public void OnClick(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("I was " + context.phase);
        }
    }
}

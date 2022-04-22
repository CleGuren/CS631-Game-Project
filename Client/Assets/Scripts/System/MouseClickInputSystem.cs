using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClickInputSystem : MonoBehaviour
{
    private Camera mainCamera;
    private PlayerInputSystem playerIS;

    public void Awake() {
        playerIS = new PlayerInputSystem();
        mainCamera = Camera.main;

        // playerIS.Player.Click.performed += OnClick;
    } 

    public void Start() {
        playerIS.Player.Click.started += _ => DetectObject();
        playerIS.Player.Click.performed += OnClick;
    }

    public void OnEnable() {
        playerIS.Player.Enable();
    }

    public void OnDisable() {
        playerIS.Player.Disable();
    }

    public void DetectObject() {
        Ray ray = mainCamera.ScreenPointToRay(playerIS.Player.Position.ReadValue<Vector2>());
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null) {
            Debug.Log("2D hit: " + hits2D.collider.tag);
            hits2D.collider.GetComponent<IClickableObject>().onClickAction();
        }
    }

    public void OnClick(InputAction.CallbackContext context) {
        if (context.performed) {
                Debug.Log("I was " + context.phase);
        }
    }
}

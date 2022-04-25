using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class devMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    public InputAction playerControls;
    private Rigidbody2D RigidBodyComponent;

    private Vector2 movement;

    void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody2D>();

        // Camera
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<Behavior>().SetCameraTarget(transform);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        movement = playerControls.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        RigidBodyComponent.MovePosition(RigidBodyComponent.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}

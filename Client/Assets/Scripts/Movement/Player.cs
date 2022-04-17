using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    public InputAction playerControls;
    private Rigidbody2D RigidBodyComponent;
    private Animator AnimationController;

    public int playerID { get; set; }

    Vector2 movement;

    private void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<Animator>();
        SetCamera();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        /* NEW SYSTEM INPUT HANDLING */
        movement = playerControls.ReadValue<Vector2>();

        // Animation
        AnimationController.SetFloat("Horizontal", movement.x);
        AnimationController.SetFloat("Vertical", movement.y);
        AnimationController.SetFloat("Speed", movement.sqrMagnitude);

        // Character Flip
        if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        RigidBodyComponent.MovePosition(RigidBodyComponent.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // If player is client's player, set main camera to follow this player object
    private void SetCamera()
    {
        if (Constants.USER_ID == playerID)
        {
            GameObject mainCamera = GameObject.Find("Main Camera");
            mainCamera.GetComponent<Behavior>().SetCameraTarget(transform);
        }
    }
}

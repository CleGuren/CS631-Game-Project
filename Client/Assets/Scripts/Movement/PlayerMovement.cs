using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public Rigidbody2D RigidBodyComponent;
    public Animator AnimationController;
    public InputAction playerControls;

    Vector2 movement;

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
        /* OLD SYSTEM INPUT HANDLING */
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        // movement.Normalize();
        
        /* NEW SYSTEM INPUT HANDLING */
        movement = playerControls.ReadValue<Vector2>();

        AnimationController.SetFloat("Horizontal", movement.x);
        AnimationController.SetFloat("Vertical", movement.y);
        AnimationController.SetFloat("Speed", movement.sqrMagnitude);

        // Debug.Log("movement.x =" + movement.x);
        // if (movement.x < 0) { 
        //     AnimationController.SetBool("isFacingRight", false);
        // } else if (movement.x > 0) {
        //     AnimationController.SetBool("isFacingRight", true);
        // }

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
}

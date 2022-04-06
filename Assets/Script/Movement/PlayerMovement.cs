using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public Rigidbody2D RigidBodyComponent;
    public Animator AnimationController;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        AnimationController.SetFloat("Horizontal", movement.x);
        AnimationController.SetFloat("Vertical", movement.y);
        AnimationController.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x < 0) { 
            AnimationController.SetBool("isFacingRight", false);
        } else if (movement.x > 0) {
            AnimationController.SetBool("isFacingRight", true);
        }
    }

    void FixedUpdate() {
        RigidBodyComponent.MovePosition(RigidBodyComponent.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

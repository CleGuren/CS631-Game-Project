using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public Rigidbody2D RigidBodyComponent;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        Vector2 charScale = transform.localScale;

        if (movement.x < 0) { 
            charScale.x = -1;
        }

        if (movement.x > 0) {
            charScale.x = 1;
        }
        
        transform.localScale = charScale;
    }

    void FixedUpdate() {
        RigidBodyComponent.MovePosition(RigidBodyComponent.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

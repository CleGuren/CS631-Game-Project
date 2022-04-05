using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Movespeed = 5;
    public Rigidbody2D RigidBodyComponent;

    // Update is called once per frame
    void Update()
    {
        Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class devPlayer : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Animator AnimationController;
    public InputAction playerControls;
    private Rigidbody2D RigidBodyComponent;

    public int playerID { get; set; }
    public string username { get; set; }

    private Vector2 movement;
    private float spawnMovementDelay = 1.8f;

    private void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody2D>();
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<Behavior>().SetCameraTarget(transform);
    }

    private void OnEnable()
    {
        Invoke(nameof(EnablePlayerMovement), spawnMovementDelay);
    }

    private void EnablePlayerMovement()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
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

    public void DespawnPlayer()
    {
        Destroy(gameObject);
    }
}

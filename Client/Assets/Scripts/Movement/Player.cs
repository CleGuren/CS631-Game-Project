using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Animator AnimationController;
    public InputAction playerControls;
    private Rigidbody2D RigidBodyComponent;

    private GameObject mainObject;
    private ConnectionManager cManager;

    public int playerID { get; set; }
    public string username { get; set; }

<<<<<<< HEAD
    private Vector2 movement;
    private float spawnMovementDelay = 1.8f;
=======
    private int otherID;
    private Vector2 otherMove;

    Vector2 movement;
>>>>>>> test

    private void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody2D>();
        mainObject = GameObject.Find("Network Manager");
        cManager = mainObject.GetComponent<ConnectionManager>();
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
        if (playerID == Constants.USER_ID)
        {
            movement = playerControls.ReadValue<Vector2>();
            if (movement.x != 0 || movement.y != 0) {
                cManager.send(requestMove(playerID, movement.x, movement.y));
            }
        }

        if (playerID == otherID) {
            movement = otherMove;
            otherMove.x = 0;
            otherMove.y = 0;
        }

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
    public void SetCamera()
    {
        if (Constants.USER_ID == playerID)
        {
            GameObject mainCamera = GameObject.Find("Main Camera");
            mainCamera.GetComponent<Behavior>().SetCameraTarget(transform);
        }
    }

    public void DespawnPlayer()
    {
        Destroy(gameObject);
    }

    public RequestMove requestMove(int id, float x, float y)
    {
        RequestMove request = new RequestMove();
        request.send(id, x, y);
        //print(username + ", " + password);
        return request;
    }

    public void responseMove(int id, float x, float y) {
        otherID = id;
        otherMove.x = x;
        otherMove.y = y;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [Header("Enemy Setting")]
    [SerializeField] float movementSpeed = 20f;

    [Header("Roam Setting")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] float roamRange;

    private bool isWandering = false;
    private bool isWalking = false;
    private bool isWalkingBackToSpawn = false;
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if (isWalking == true)
        {
            rb.velocity = direction * movementSpeed;
        }

        if (isWalkingBackToSpawn == true)
        {
            rb.velocity = direction * movementSpeed / 2;
        }
    }

    IEnumerator Wander()
    {
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        // Wait
        yield return new WaitForSeconds(walkWait);

        // Walk
        Debug.Log("Normal");
        isWalking = true;
        direction = Random.insideUnitCircle;
        FlipDirection(direction);

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        // Out of bound

        isWalkingBackToSpawn = true;

        float distance = Vector2.Distance(spawnPoint.position, transform.position); // Current distance alway

        while (distance > roamRange)
        {
            Debug.Log("Back");
            direction = (spawnPoint.position - transform.position).normalized;

            yield return new WaitForSeconds(1);

            distance = Vector2.Distance(spawnPoint.position, transform.position); // New distance alway
        }

        isWalkingBackToSpawn = false;

        isWandering = false;
    }

    private void FlipDirection(Vector2 direction)
    {
        if (direction.x > 0) // Going Right
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else // Going Left
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

}

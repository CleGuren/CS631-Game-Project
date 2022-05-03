using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    [SerializeField] private Transform location;

    private void OnTriggerEnter2D(Collider2D other) {
        if (location && other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Teleport(location.position.x, location.position.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTestShop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Town Hub");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTutorialFromTownHub : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Tutorial");
        }
    }
}

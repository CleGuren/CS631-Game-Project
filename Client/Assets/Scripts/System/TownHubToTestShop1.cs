using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownHubToTestShop1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            // var theThing = GameObject.FindGameObjectWithTag("GameTownHubMusic");
            // // Debug.Log("The other game event is: " + theThing + ".");
            // // Debug.Log("The stored event is: " + GameManager.startTownHubMusicEvent + ".");
            // Destroy(theThing);
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Test Shop");
        }
    }
}

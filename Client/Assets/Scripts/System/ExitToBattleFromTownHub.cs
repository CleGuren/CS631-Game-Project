using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToBattleFromTownHub : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            // var theThing = GameObject.FindGameObjectWithTag("GameTownHubMusic");
            // Destroy(theThing);
            AkSoundEngine.StopAll();
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Battle Scene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTutorialFromTownHub : MonoBehaviour
{
    //[SerializeField] private AK.Wwise.State currentState;
   // [SerializeField] private AK.Wwise.Event currentEvent;
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            var theThing = GameObject.FindGameObjectWithTag("GameTownHubMusic");
            Destroy(theThing);
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("Tutorial");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTrigger : MonoBehaviour
{
    public string EntityTag;
    public string SceneToLoad;
    private VectorValue PlayerValueStorage;

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            // PlayerValueStorage.CurrentPosition = GameObject.Find("Player").transform.position;
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

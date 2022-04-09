using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTrigger : MonoBehaviour
{
    public string EntityTag;

    void OnTriggerEnter2D(Collider2D entity) {
        if (entity.tag == "Player") {
            SceneManager.LoadScene("Battle Scene");
        }
    }
}

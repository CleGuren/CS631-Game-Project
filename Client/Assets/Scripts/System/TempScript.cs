using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TempScript : MonoBehaviour
{
    public void ChangeScene() {
        var theThing = GameObject.FindGameObjectWithTag("GameBattleMusic");
        Destroy(theThing);
        SceneManager.LoadScene("Tutorial");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TempScript : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene("Tutorial");
    }
}

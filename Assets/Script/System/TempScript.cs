using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempScript : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene("Tutorial");
    }
}

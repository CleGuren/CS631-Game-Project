using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitTheApp()
    {
        Debug.Log("Quit the Game");
        AkSoundEngine.StopAll();
        Application.Quit();
    }
}

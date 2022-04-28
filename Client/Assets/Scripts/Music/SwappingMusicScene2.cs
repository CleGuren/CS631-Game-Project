using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwappingMusicScene : MonoBehaviour
{
    void Update()
    {
        if (
            SceneManager.GetActiveScene().name != "LoginScene"
            && SceneManager.GetActiveScene().name != "RegistrationScene"
            && SceneManager.GetActiveScene().name != "MenuScene"
            && SceneManager.GetActiveScene().name != "OpeningScene"
            && SceneManager.GetActiveScene().name != "OptionsScene"
        )
        {
           AkSoundEngine.StopAll();
        }
    }
}

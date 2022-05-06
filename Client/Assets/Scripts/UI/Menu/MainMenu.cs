using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private NetworkManager networkManager;
    private MessageQueue msgQueue;
    private void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();
    }

    public void Login()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void Register()
    {
        SceneManager.LoadScene("RegistrationScene");
    }

    public void QuitGame()  
    {
        Debug.Log("QUIT THE GAME");
        AkSoundEngine.StopAll();
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
}

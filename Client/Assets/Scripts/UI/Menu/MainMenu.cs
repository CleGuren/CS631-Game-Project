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
        // change main menu to game scene
        SceneManager.LoadScene("LoginScene");
        
    }

    public void Register()
    {
        // this needs to send the username and password
        // to the backend
        // it will also send the user back to the main menu
        // and show a message displaying the the new user has been created
        // or the user already exists
        SceneManager.LoadScene("RegistrationScene");
    }

    public void QuitGame()  // doesn't quit the game yet
    {
        Debug.Log("QUIT THE GAME");
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

    // public void LoginSuccessfulLoading()
    // {
    //     // this needs  to connect to the db and retrieve the username/password data
    //     // if the login exists, then the loading screen will appear
    //     // if the login doesn't exist or the password is incorrect,
    //     // it will show an error box
    //     // otherwise, the loading scene will display while assets load in the background
    //     SceneManager.LoadScene("LoadingScene");
    //     // once the login data has been retrieved, a function should be called
    //     // to transition to the townhub
    // }
}

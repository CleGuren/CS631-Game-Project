using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

// this script allows for the menus to be navigated via tab and enter,
// and navigates back to the main menu with the escape key

public class ChangeInput : MonoBehaviour
{
    private EventSystem eventSystem;
    public Selectable firstInput;
    public Button submitButton;
   // public Scene currentScene = SceneManager.GetActiveScene();

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        firstInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        // string sceneName = currentScene.name;
        // this will allow the menus to be tabbed through
        if (Keyboard.current.tabKey.wasPressedThisFrame && Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            Selectable previous = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }
        }
        else if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }else if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                submitButton.onClick.Invoke();
                Debug.Log("Button pressed");
            }
            // TODO - check if the current scene is the "MainMenu"
            // if the current scene is not MainMenu, then call the MenuScene
        }else if (Keyboard.current.escapeKey.wasPressedThisFrame /*&& currentScene != SceneManager.GetSceneByName("MainMenu")*/)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}

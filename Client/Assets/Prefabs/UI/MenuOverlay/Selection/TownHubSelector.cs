using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Event = AK.Wwise.Event;

public class TownHubSelector : MonoBehaviour
{
    [SerializeField] private AK.Wwise.State currentState;
   // [SerializeField] private AK.Wwise.Event stopEvent;
   // [SerializeField] private AK.Wwise.Event currentEvent;
    public void TownHubOnButtonClick()
    {
        currentState.SetValue();
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name != "Town Hub")
        {
            AkSoundEngine.StopAll();
            currentState.SetValue();
            SceneManager.LoadScene("Town Hub");
        }
    }
}
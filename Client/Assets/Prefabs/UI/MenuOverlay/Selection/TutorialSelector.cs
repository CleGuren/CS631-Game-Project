using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSelector : MonoBehaviour
{
    [SerializeField] private AK.Wwise.State currentState;
    //[SerializeField] private AK.Wwise.Event stopEvent;
    //[SerializeField] private AK.Wwise.Event currentEvent;
    public void TutorialOnButtonClick()
    {
        currentState.SetValue();
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            
            AkSoundEngine.StopAll();
            currentState.SetValue();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
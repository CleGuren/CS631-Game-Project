using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSelector : MonoBehaviour
{
    //[SerializeField] private AK.Wwise.State currentState;
    [SerializeField] private AK.Wwise.Event stopEvent;
    //[SerializeField] private AK.Wwise.Event currentEvent;
    public void TutorialOnButtonClick()
    {
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
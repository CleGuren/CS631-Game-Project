using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = AK.Wwise.Event;

public class MainMenuMusic : MonoBehaviour
{
    //public static MainMenuMusic instance;
    
   [SerializeField] private AK.Wwise.Event currentEvent;
   [SerializeField] private AK.Wwise.Event stopEvent;
   
   private void Start()
   {
        GameManager.startMainMusicEvent = currentEvent;
        currentEvent.Post(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

   private void OnDestroy()
   {
       stopEvent.Post(gameObject);
       currentEvent.Stop(gameObject);
   }
}

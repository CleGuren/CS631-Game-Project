using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = AK.Wwise.Event;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic instance;
    
   [SerializeField] private AK.Wwise.Event currentEvent;

   private void Start()
   {
       
   }

   private void Awake()
   {
        GameManager.startMainMusicEvent = currentEvent;
        currentEvent.Post(gameObject);
        DontDestroyOnLoad(gameObject);
    }

   private void OnDestroy()
   {
       currentEvent.Stop(gameObject);
   }
}

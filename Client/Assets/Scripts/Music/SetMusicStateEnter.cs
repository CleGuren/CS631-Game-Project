using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = AK.Wwise.Event;


public class SetMusicStateEnter : MonoBehaviour
{
   public AK.Wwise.State currentState;
   public AK.Wwise.Event currentEvent;
   //public AK.Wwise.Event currentEvent;
  // [SerializeField] private AK.Wwise.Event Stop_Gameplay_Music;
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            // // AkSoundEngine.StopAll();
            // //currentState.SetValue();
            // //Play_Gameplay_Music.Post(gameObject);
            // AkSoundEngine.StopAll();
            // currentEvent.Post(gameObject);
            // currentState.SetValue();
            // Debug.Log(currentState);
            
        }
    }
}

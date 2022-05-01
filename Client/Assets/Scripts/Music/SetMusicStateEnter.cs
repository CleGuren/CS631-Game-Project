using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = AK.Wwise.Event;


public class SetMusicStateEnter : MonoBehaviour
{
   public AK.Wwise.State currentState;
   private void OnTriggerEnter(Collider entity)
    {
        if (entity.CompareTag("Player"))
        {
            currentState.SetValue();
        }
    }
}

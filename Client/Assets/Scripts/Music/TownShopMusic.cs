using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event = AK.Wwise.Event;

public class TownShopMusic : MonoBehaviour
{
    //[SerializeField] private AK.Wwise.Event currentEvent;
    [SerializeField] private AK.Wwise.State stateEvent;
    private void Awake()
    {
        //GameManager.startTownHubMusicEvent = currentEvent;
        stateEvent.SetValue();
            
       // currentEvent.Post(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // private void OnDestroy()
    // {
    //     currentEvent.Stop(gameObject);
    // }
}

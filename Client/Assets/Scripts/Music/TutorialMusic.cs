using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Event = AK.Wwise.Event;

public class TutorialMusic : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event currentEvent;
   // [SerializeField] private AK.Wwise.State currentState;
    private void Awake()
    {
        GameManager.startTownHubMusicEvent = currentEvent;
        currentEvent.Post(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        currentEvent.Stop(gameObject);
    }
}
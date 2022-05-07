using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event currentEvent;
    void Awake()
    {
        currentEvent.Post(gameObject);
    }

    private void OnDestroy()
    {
        currentEvent.Post(gameObject);
    }
}

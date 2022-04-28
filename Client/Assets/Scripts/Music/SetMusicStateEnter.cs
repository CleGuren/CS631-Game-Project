using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicStateEnter : MonoBehaviour
{
    public AK.Wwise.State onTriggerEnterState;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerEnterState.SetValue();
        }
    }
}

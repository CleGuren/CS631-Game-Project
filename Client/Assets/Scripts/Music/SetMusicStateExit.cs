using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicStateExit : MonoBehaviour
{
    public AK.Wwise.State onTriggerExitState;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerExitState.SetValue();
        }
    }
}

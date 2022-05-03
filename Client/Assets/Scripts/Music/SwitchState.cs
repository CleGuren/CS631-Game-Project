using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    [SerializeField] private AK.Wwise.State currentState;
    private void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.CompareTag("Player"))
        {
            currentState.SetValue();
            Debug.Log("Collision Detected");
        }
    }
}

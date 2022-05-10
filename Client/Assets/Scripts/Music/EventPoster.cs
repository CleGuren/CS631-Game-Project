using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPoster : MonoBehaviour
{
    public void PlaySound(string EventName)
    {
        AkSoundEngine.PostEvent(EventName, this.gameObject);
    }
}

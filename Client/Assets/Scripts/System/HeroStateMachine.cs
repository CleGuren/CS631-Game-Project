using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour
{
    public enum State { PROCESSING, ADDTOLIST, SELECTING, ACTION, DEAD }
    public HeroBase myValue;
    public State currentState;
}

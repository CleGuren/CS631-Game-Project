using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour
// , IClickableObject
{
    public enum State { PROCESSING, ADDTOLIST, SELECTING, ACTION, DEAD }
    public HeroBase myValue;
    public State currentState;

    // public void onClickAction() {
    //     DisplayCharInformation(myValue);
    // }
}

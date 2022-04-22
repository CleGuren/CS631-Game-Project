using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour, IClickableObject
{
    public enum State { PROCESSING, ADDTOLIST, SELECTING, ACTION, DEAD }
    public HeroBase myValue;
    public State currentState;
    private BattleSystem curr_BS;

    public void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
    }

    public void onClickAction() {
        curr_BS.DisplayCharInformation(myValue);
    }
}

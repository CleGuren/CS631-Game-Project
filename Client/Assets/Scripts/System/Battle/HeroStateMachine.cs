using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour, IClickableObject
{
    public enum State { WAITING, SELECTING, ADDTOLIST, ACTION, DEAD }
    public HeroBase myValue;
    public State currentState;
    private BattleSystem curr_BS;
    private bool alive = true;
    // private float curr_cooldown = 0f;
    // private float max_cooldown = 5f;
    void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
    }

    void Start() {
        currentState = State.WAITING;
    }

    void Update() {
        switch (currentState) {
            case (State.WAITING) : 
                //maybe do something here
                break;
            case (State.SELECTING) : 
                break;
            case (State.ADDTOLIST) : 
                break;
            case (State.ACTION) : 
                break;
            case (State.DEAD) : 
                if (!alive) {

                } else {
                    //change tag
                    //not targetable by enemies
                    //not manageable
                    //change color / dead animation
                    alive = false;
                    //reset heroinput
                }
                break;
        }
    }

    public void onClickAction() {
        curr_BS.DisplayCharInformation(this);
    }

    public void TakeDamage(float damageTaken) {
        myValue.currentHP -= damageTaken;
        if (myValue.currentHP <= 0) {
            currentState = State.DEAD;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum State { START, WAITING, CHOOSE_ACTION, DEAD }
    public EnemyBase Enemy;
    public State currentState;
    
    private Vector3 startPosition;
    private BattleSystem curr_BS;

    void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
    }

    void Start() {
        currentState = State.START;
        startPosition = transform.position;
    }

    void Update() {
        switch (currentState) {
            case (State.START) : 
                //Starting state doing nothing atm but can be 
                //useful later in case we want to simulate boss
                //opening trigger or enemy opening animation
                currentState = State.WAITING;
                break;
            case (State.WAITING) : 
                //Idle state waiting for the player to finish their
                //turn
                if (!(curr_BS.PlayerTurn)) {
                    currentState = State.CHOOSE_ACTION;
                }
                break;
            case (State.CHOOSE_ACTION) : 
                ChooseAction();
                curr_BS.PlayerTurn = true;
                currentState = State.WAITING;
                break;
            case (State.DEAD) : 
                break;
        }
    }

    void ChooseAction() {
        HandleTurn myAttack = new HandleTurn();
        myAttack.attackerName = Enemy.name;
        myAttack.Attacker = this.gameObject;
        myAttack.Targer = curr_BS.playerParty[Random.Range(0, curr_BS.playerParty.Count)];

        curr_BS.CollectActions(myAttack);
    }

    // some function() {
    //     DoDamage();
    // }

    // void DoDamage() {
    //     float calc_damage = Enemy.currentAtk + BSM.PerformList[0].chosenAtk.atkDamage;
    //     CharToAttack.GetComponent<HeroStateMachine>().TakeDamage(calc_damage);
    // }
}

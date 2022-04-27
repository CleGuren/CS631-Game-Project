using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum State { START, CHOOSE_ACTION, WAITING, PERFORM_ACTION, DEAD }
    public EnemyBase Enemy;
    public State currentState;
    public GameObject HeroToAttack;
    
    private Vector3 startPosition;
    private BattleSystem curr_BS;
    private bool actionStarted;

    void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
    }

    void Start() {
        currentState = State.START;
        startPosition = transform.position;
    }

    /*start
    choose action
    waiting*/

    void Update() {
        switch (currentState) {
            case (State.START) : 
                //Starting state doing nothing atm but can be 
                //useful later in case we want to simulate boss
                //opening trigger or enemy opening animation
                currentState = State.CHOOSE_ACTION;
                break;
            case (State.CHOOSE_ACTION) : 
                ChooseAction();
                Debug.Log("ActionList.count: " + curr_BS.EnemyActionList.Count);
                currentState = State.WAITING;
                break;
            case (State.WAITING) : 
                //Idle state waiting for battle system to give the go
                if (curr_BS.EnemyActionList.Count == 0) {
                    currentState = State.CHOOSE_ACTION;
                }
                break;
            case(State.PERFORM_ACTION) : 
                StartCoroutine(ActionTime());
                currentState = State.WAITING;
                break;
            case (State.DEAD) : 
                break;
        }
    }

    void ChooseAction() {
        HandleTurn myAttack = new HandleTurn();
        myAttack.attackerName = Enemy.name + "(Clone)";
        myAttack.Type = "Enemy";
        myAttack.Attacker = this.gameObject;
        myAttack.Target = curr_BS.playerParty[Random.Range(0, curr_BS.playerParty.Count)];

        curr_BS.CollectActions(myAttack);
    }

    private IEnumerator ActionTime() {
        if (actionStarted) {
            yield break;
        }

        actionStarted = true;

        //plays animation

        //wait a bit
        yield return new WaitForSeconds(2f);
        //do damge
        //remove the action from list
        curr_BS.EnemyActionList.RemoveAt(0);

        actionStarted = false;
    }

    // some function() {
    //     DoDamage();
    // }

    // void DoDamage() {
    //     float calc_damage = Enemy.currentAtk + BSM.PerformList[0].chosenAtk.atkDamage;
    //     CharToAttack.GetComponent<HeroStateMachine>().TakeDamage(calc_damage);
    // }
}

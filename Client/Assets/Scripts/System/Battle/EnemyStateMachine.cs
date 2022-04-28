using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum State { START, CHOOSE_ACTION, WAITING, PERFORM_ACTION, DEAD }
    public EnemyBase Enemy;
    public State currentState;
    public GameObject HeroToAttack;
    private BattleSystem curr_BS;
    private bool actionStarted;
    private int currentChargeDiamond;
    public int CurrentDiamond { get {return currentChargeDiamond;} set {currentChargeDiamond = value;} } 

    void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
    }

    void Start() {
        currentState = State.START;
        currentChargeDiamond = 0;
    }

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
        myAttack.attackerName = Enemy.enemyName + "(Clone)";
        myAttack.Type = "Enemy";
        myAttack.Attacker = this.gameObject;
        myAttack.Target = curr_BS.playerParty[Random.Range(0, curr_BS.playerParty.Count)];
        if (currentChargeDiamond == Enemy.ChargeDiamond) {
            //choose charge attack
            myAttack.chosenAtk = Enemy.mySkill[Random.Range(1, Enemy.mySkill.Count)];
            //reset charge diamond to 0
            // currentChargeDiamond = 0;
        } else {
            //choose regular attack
            myAttack.chosenAtk = Enemy.mySkill[0];
            //increase charge diamond by 1
            // currentChargeDiamond++;
        }
        curr_BS.CollectEnemyAction(myAttack);
    }

    private IEnumerator ActionTime() {
        if (actionStarted) {
            yield break;
        }

        actionStarted = true;

        //plays animation

        //wait a bit
        yield return new WaitForSeconds(1f);
        //do damge
        DoDamage();
        //remove the action from list
        curr_BS.EnemyActionList.RemoveAt(0);

        actionStarted = false;
    }

    void DoDamage() { 
        float calc_damage = (Enemy.currentAtk * curr_BS.EnemyActionList[0].chosenAtk.skillBaseDMG) - (0.2f * HeroToAttack.GetComponent<HeroStateMachine>().myValue.currentDef);
        Debug.Log(Enemy.enemyName + " has performed " + curr_BS.EnemyActionList[0].chosenAtk.skillName + " and dealt " + calc_damage + " damage to " + curr_BS.EnemyActionList[0].Target.GetComponent<HeroStateMachine>().myValue.charName + "!");
        Debug.Log(curr_BS.EnemyActionList[0].chosenAtk.skillDescription);
        if (calc_damage <= 0) {
            calc_damage = 0;
        }
        HeroToAttack.GetComponent<HeroStateMachine>().TakeDamage(calc_damage);
    }
}

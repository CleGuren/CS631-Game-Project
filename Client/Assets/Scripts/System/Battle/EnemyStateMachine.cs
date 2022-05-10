using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum State { START, IDLE, CHOOSE_ACTION, WAITING, PERFORM_ACTION, DEAD }
    public EnemyBase Enemy;
    public State currentState;
    public GameObject HeroToAttack;
    public Animator EnemyAnimator;
    private BattleSystem curr_BS;
    private int currentChargeDiamond;
    private bool alive = true;
    [SerializeField] private bool actionStarted;
    [SerializeField] private bool animFinished;
    [SerializeField] private DamageDisplayManager DDM;
    public int CurrentDiamond { get {return currentChargeDiamond;} set {currentChargeDiamond = value;} } 
    void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
    }

    void Start() {
        animFinished = false;
        actionStarted = false;
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
            case (State.IDLE) : 
                break;
            case (State.CHOOSE_ACTION) : 
                ChooseAction();
                // Debug.Log("ActionList.count: " + curr_BS.EnemyActionList.Count);
                currentState = State.WAITING;
                break;
            case (State.WAITING) : 
                //Idle state waiting for battle system to give the go
                if (curr_BS.EnemyActionList.Count == 0) {
                    currentState = State.CHOOSE_ACTION;
                }
                break;
            case(State.PERFORM_ACTION) : 
                ActionTime();
                if (animFinished) {
                    animFinished = false;
                    actionStarted = false;
                    if (curr_BS.CharsAreDead()) {
                        currentState = State.IDLE;
                    } else currentState = State.WAITING;
                }
                break;
            case (State.DEAD) : 
                if (!alive) {
                    return;
                } else {
                    alive = false;
                    EnemyAnimator.Play("Dead");
                    curr_BS.myEnemy.Remove(this.gameObject);
                }
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
        } else {
            //choose regular attack
            myAttack.chosenAtk = Enemy.mySkill[0];
        }
        curr_BS.CollectEnemyAction(myAttack);
    }

    void ActionTime() {
        //plays animation
        if (!actionStarted) {
            actionStarted = true;
            if (curr_BS.EnemyActionList[0].chosenAtk == Enemy.mySkill[0]) {
                EnemyAnimator.Play("Attack");
            } else EnemyAnimator.Play("Special");
        }
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

    public void TakeDamage(float damageTaken) {
        DDM.displayDamage(damageTaken);
        Enemy.currentHP -= damageTaken;
        if (Enemy.currentHP <= 0) {
            currentState = State.DEAD;
        }
    }

    public void AnimationDone() {
        EnemyAnimator.Play("Idle");
        curr_BS.EnemyActionList.RemoveAt(0);
        animFinished = true;
    }

    public bool isIdle() {
        return currentState == State.WAITING ? true : false;
    }

    public void PlaySound(string path) {
        AkSoundEngine.PostEvent(path, this.gameObject);
    }
}

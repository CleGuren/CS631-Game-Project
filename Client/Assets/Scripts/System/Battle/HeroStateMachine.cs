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
    private bool actionStarted;
    [SerializeField] private DamageDisplayManager DDM;
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
                StartCoroutine(ActionTime());
                currentState = State.WAITING;
                break;
            case (State.DEAD) : 
                if (!alive) {
                    return;
                } else {
                    //change tag
                    //not targetable by enemies
                    curr_BS.playerParty.Remove(this.gameObject);
                    //not manageable
                    //change color / dead animation
                    alive = false;
                    //reset heroinput
                }
                break;
        }
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
        curr_BS.CharacterActionList.RemoveAt(0);

        actionStarted = false;
    }

    public void onClickAction() {
        curr_BS.DisplayCharInformation(this);
    }

    public void TakeDamage(float damageTaken) {
        DDM.displayDamage(damageTaken);
        myValue.currentHP -= damageTaken;
        if (myValue.currentHP <= 0) {
            currentState = State.DEAD;
        }
    }

    void DoDamage() {
        float calc_damage = myValue.currentAtk * curr_BS.CharacterActionList[0].chosenAtk.skillBaseDMG - 0.2f * curr_BS.myEnemy[0].GetComponent<EnemyStateMachine>().Enemy.currentDef;
        if (calc_damage <= 0) {
            calc_damage = 1;
        }
        curr_BS.CharacterActionList[0].Target.GetComponent<EnemyStateMachine>().TakeDamage(calc_damage);
    }
}

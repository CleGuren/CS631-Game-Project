using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour, IClickableObject
{
    public enum State { WAITING, SELECTING, ADDTOLIST, ACTION, DEAD }
    public HeroBase myValue;
    public State currentState;
    public List<int> CurrentSkillCdList;
    private BattleSystem curr_BS;
    private bool alive = true;
    private bool actionStarted;
    [SerializeField] private DamageDisplayManager DDM;
    void Awake() {
        curr_BS = GameObject.Find("BattleOverseer").GetComponent<BattleSystem>();
        CurrentSkillCdList = new List<int>();
    }

    void Start() {
        for (int i = 0; i < myValue.mySkill.Count; ++i) {
            int cdNumber = myValue.mySkill[i].skillCooldown;
            CurrentSkillCdList.Add(cdNumber);
        }
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
        // if (isNormalAttack) {
        //     yield return new WaitForSeconds(0.5f);
        //     DoDamage();
        // } else {
            yield return new WaitForSeconds(1f);
            //do damge
            DoDamage();
        // }
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

    public int SkillCurrentCD(int skillNumber) {
        return CurrentSkillCdList[skillNumber];
    }

    public int SkillCD(int skillNumber) {
        return myValue.mySkill[skillNumber].skillCooldown;
    }

    public void SkillEnterCooldown(int skillNumber) {
        CurrentSkillCdList[skillNumber] = 0;
    }

    public void UpdateSkillCD() {
        for (int i = 1; i < CurrentSkillCdList.Count; ++i) {
            if (CurrentSkillCdList[i] < myValue.mySkill[i].skillCooldown) {
                CurrentSkillCdList[i] += 1;
            }
        }
    }

    public int RollMA_Dice() {
        if (currentState != State.DEAD) {
            int DA_Dice = Random.Range(0, 100);
            int TA_Dice = Random.Range(0, 100);
            if (DA_Dice < myValue.baseDA) {
                return 1;
            } else if (TA_Dice < myValue.baseTA) {
                return 2;
            } else return 0;
        } else return -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, TRANSITIONING, VICTORIOUS, DEFEAT }

    //Entities and Actions
    public List<HandleTurn> EnemyActionList = new List<HandleTurn>();
    public List<HandleTurn> CharacterActionList = new List<HandleTurn>();
    public List<GameObject> playerParty = new List<GameObject>();
    public List<GameObject> myEnemy = new List<GameObject>();
    public HandleTurn PlayerChoice;

    //GameObjects
    public GameObject Character1Prefab;
    public GameObject Character2Prefab;
    public GameObject Character3Prefab;
    public GameObject Character4Prefab;
    public GameObject Enemy1Prefab;
    public Transform Character1Pos;
    public Transform Character2Pos;
    public Transform Character3Pos;
    public Transform Character4Pos;
    public Transform Enemy1Pos;
    public Button AttackButton;
    public Button NoButton;
    private HeroStateMachine SelectedChar;
    
    //UI
    private GameObject CharacterActionBox;
    private ChargeDiamond ChargeDiamondUI;
    private Text CharNameText;
    private Text CharLevel;
    private Text HP_Value;
    private Text Skill1_CD;
    private Text Skill2_CD;
    private Text Skill3_CD;
    private Text Skill4_CD;
    private TextMeshProUGUI TurnIndicator;
    private Image CharPortrait;
    private Image HP_Bar;
    private Image Boss_HP_Bar;
    private Button Skill1;
    private Button Skill2;
    private Button Skill3;
    private Button Skill4;
    private int turnNumber;
    
    //Conditional States
    public BattleState curr_state;
    private bool playerTurn;
    private bool triggerUI; 
    private bool victorious = true;
    private bool defeat = true;
    
    public void Awake() {
        CharacterActionBox = GameObject.Find("Character Action Box");
        CharPortrait = GameObject.Find("Character Portrait").GetComponent<Image>();
        CharNameText = GameObject.Find("Character Name").GetComponent<Text>();
        CharLevel = GameObject.Find("Character Level").GetComponent<Text>();
        HP_Bar = GameObject.Find("Character HP Bar").GetComponent<Image>();
        Boss_HP_Bar = GameObject.Find("Boss Health Bar").GetComponent<Image>();
        HP_Value = GameObject.Find("HP Value").GetComponent<Text>();
        Skill1 = GameObject.Find("Skill 1").GetComponent<Button>();
        Skill2 = GameObject.Find("Skill 2").GetComponent<Button>();
        Skill3 = GameObject.Find("Skill 3").GetComponent<Button>();
        Skill4 = GameObject.Find("Skill 4").GetComponent<Button>();
        Skill1_CD = GameObject.Find("Skill 1 CD").GetComponent<Text>();
        Skill2_CD = GameObject.Find("Skill 2 CD").GetComponent<Text>();
        Skill3_CD = GameObject.Find("Skill 3 CD").GetComponent<Text>();
        Skill4_CD = GameObject.Find("Skill 4 CD").GetComponent<Text>();
        TurnIndicator = GameObject.Find("Turn Number").GetComponent<TextMeshProUGUI>();
        CharacterActionBox.SetActive(false);
        PlayerChoice = new HandleTurn();
        ChargeDiamondUI = GameObject.Find("Charge Diamond Box").GetComponent<ChargeDiamond>();
    }

    void Start()
    {
        curr_state = BattleState.START;
        playerTurn = true;
        ChargeDiamondUI.HideDiamonds();
        turnNumber = 1;
        TurnIndicator.text = turnNumber.ToString();
    }

    void Update() {
        //Optimized for single enemy
        switch(curr_state) {
            case(BattleState.START) : 
                SpawnEntities();
                playerParty.AddRange(GameObject.FindGameObjectsWithTag("Character"));
                myEnemy.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
                ChargeDiamondUI.SetDiamonds(myEnemy[0].GetComponent<EnemyStateMachine>().Enemy.ChargeDiamond);
                curr_state = BattleState.PLAYERTURN;
                break;
            case(BattleState.PLAYERTURN) : 
                //action queued
                if (CharacterActionList.Count > 0) {
                    //only perform action when character is idling
                    if (CharacterActionList[0].Attacker.GetComponent<HeroStateMachine>().isIdle()) { 
                        CharacterActionList[0].Attacker.GetComponent<HeroStateMachine>().currentState = HeroStateMachine.State.ACTION;
                        //switch to victorious state if no enemy remaining
                    }
                    if (EnemiesAreDead()) {
                        CharacterActionList.Clear();
                        curr_state = BattleState.VICTORIOUS;
                    }
                }
                //update boss hp bar
                Boss_HP_Bar.transform.localScale = new Vector3(Mathf.Clamp(myEnemy[0].GetComponent<EnemyStateMachine>().Enemy.currentHP/myEnemy[0].GetComponent<EnemyStateMachine>().Enemy.maxHP, 0, 1), Boss_HP_Bar.transform.localScale.y, Boss_HP_Bar.transform.localScale.z);
                //player have initiated turn progress
                if (!playerTurn) {
                    //turn off ui, no more input
                    CharacterActionBox.SetActive(false);
                    //proceed to enemy turn after characters are done performing their action
                    if (charactersCompletedAction()) {
                        curr_state = BattleState.ENEMYTURN;
                    }
                }
                break;
            case(BattleState.ENEMYTURN) :
                if (EnemyActionList.Count > 0) {
                    //enemy perform actions
                    GameObject attackingEnemy = GameObject.Find(EnemyActionList[0].attackerName);
                    EnemyStateMachine enemyState = attackingEnemy.GetComponent<EnemyStateMachine>();
                    enemyState.HeroToAttack = EnemyActionList[0].Target;
                    enemyState.currentState = EnemyStateMachine.State.PERFORM_ACTION;
                } else {
                    if ((myEnemy[0].GetComponent<EnemyStateMachine>().CurrentDiamond == myEnemy[0].GetComponent<EnemyStateMachine>().Enemy.ChargeDiamond)) {
                        myEnemy[0].GetComponent<EnemyStateMachine>().CurrentDiamond = 0;
                        ChargeDiamondUI.ResetDiamond();
                    } else {
                        myEnemy[0].GetComponent<EnemyStateMachine>().CurrentDiamond += 1;
                        ChargeDiamondUI.GainDiamond();
                    }
                    for (int i = 0; i < playerParty.Count; i++) {
                        playerParty[i].GetComponent<HeroStateMachine>().UpdateSkillCD();
                    }
                    UpdateTurn();
                    curr_state = BattleState.TRANSITIONING;
                }
                break;
            case(BattleState.TRANSITIONING) :
                if (CharsAreDead()) {
                    curr_state = BattleState.DEFEAT;
                } else curr_state = BattleState.PLAYERTURN;
                break; 
            case(BattleState.VICTORIOUS) : 
                if (victorious) {
                    victorious = false;
                    Debug.Log("You Won!");
                }
                break;
            case(BattleState.DEFEAT) :
                if (defeat) {
                    defeat = false;
                    Debug.Log("You Lost!");
                } 
                break;
        }
    }

    void SpawnEntities() {
        Instantiate(Character1Prefab, Character1Pos);
        Instantiate(Character2Prefab, Character2Pos);
        // Instantiate(Character3Prefab, Character3Pos);
        // Instantiate(Character4Prefab, Character4Pos);
        Instantiate(Enemy1Prefab, Enemy1Pos);
    }

    void UpdateTurn() {
        turnNumber++;
        TurnIndicator.text = turnNumber.ToString();
        for (int i = 0; i < playerParty.Count; i++) {
            playerParty[i].GetComponent<HeroStateMachine>().endOfAction = false;
        }
        playerTurn = true;
    }

    public void CollectEnemyAction(HandleTurn input) {
        EnemyActionList.Add(input);
    }

    // -1 dead player
    //  0 not normal attack
    //  1 normal attack
    //  2 double attack
    //  3 triple attack 
    public void TurnProgress() {
        if (playerTurn) {
            for (int i = 0; i < playerParty.Count; i++) {
                pushNormalAttack(ProvideTurnInput(playerParty[i].GetComponent<HeroStateMachine>(), 0, playerParty[i].GetComponent<HeroStateMachine>().RollMA_Dice()));
            }
            playerTurn = false;
        }
    }

    bool charactersCompletedAction() {
        bool actionState = true;
        for (int i = 0; i < playerParty.Count; i++) {
            actionState &= playerParty[i].GetComponent<HeroStateMachine>().endOfAction;
        }
        return actionState;
    }

    void pushNormalAttack(HandleTurn CharInfo) {
        if (CharInfo.MA_Data > 0) {
            CharacterActionList.Add(CharInfo);
        } else Debug.Log("Dead character cannot attack.");
    }

    public void ToPlayerturn() {
        curr_state = BattleState.PLAYERTURN;
    }

    public void DisplayCharInformation(HeroStateMachine CharInfo) {
        CharacterActionBox.SetActive(true);
        SelectedChar = CharInfo;
        CharNameText.text = CharInfo.myValue.charName;
        CharLevel.text = "Lv." + CharInfo.myValue.level;
        CharPortrait.sprite = CharInfo.myValue.charPortrait;
        HP_Bar.transform.localScale = new Vector3(Mathf.Clamp(CharInfo.myValue.currentHP/CharInfo.myValue.maxHP, 0, 1), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);
        HP_Value.text = CharInfo.myValue.currentHP + "/" + CharInfo.myValue.maxHP;
        Skill1.image.sprite = CharInfo.myValue.mySkill[1].skillIcon;
        Skill2.image.sprite = CharInfo.myValue.mySkill[2].skillIcon;
        Skill3.image.sprite = CharInfo.myValue.mySkill[3].skillIcon;
        Skill4.image.sprite = CharInfo.myValue.mySkill[4].skillIcon;
        Skill1_CD.text = CharInfo.SkillCurrentCD(1) + "/" + CharInfo.SkillCD(1);
        Skill2_CD.text = CharInfo.SkillCurrentCD(2) + "/" + CharInfo.SkillCD(2);
        Skill3_CD.text = CharInfo.SkillCurrentCD(3) + "/" + CharInfo.SkillCD(3);
        Skill4_CD.text = CharInfo.SkillCurrentCD(4) + "/" + CharInfo.SkillCD(4);
    }

    HandleTurn ProvideTurnInput(HeroStateMachine CharInfo, int skillNumber, int MA_Data) {
        PlayerChoice = new HandleTurn();
        PlayerChoice.attackerName = CharInfo.myValue.charName;
        PlayerChoice.Type = "Character";
        PlayerChoice.Attacker = GameObject.Find(CharInfo.myValue.charName + "(Clone)");
        PlayerChoice.Target = GameObject.Find(myEnemy[0].GetComponent<EnemyStateMachine>().Enemy.enemyName + "(Clone)");
        PlayerChoice.MA_Data = MA_Data;
        PlayerChoice.chosenAtk = PlayerChoice.Attacker.GetComponent<HeroStateMachine>().myValue.mySkill[skillNumber];
        return PlayerChoice;
    }

    public void PushSkill1ToList() {
        if (SelectedChar.SkillCurrentCD(1) < SelectedChar.SkillCD(1)) {
            Debug.Log(SelectedChar.myValue.mySkill[1].skillName + " is on cooldown.");
        } else {
            CharacterActionList.Add(ProvideTurnInput(SelectedChar, 1, 0));
            SelectedChar.SkillEnterCooldown(1);
            Skill1_CD.text = SelectedChar.SkillCurrentCD(1) + "/" + SelectedChar.SkillCD(1);
        }
    }

    public void PushSkill2ToList() {
        if (SelectedChar.SkillCurrentCD(2) < SelectedChar.SkillCD(2)) {
            Debug.Log(SelectedChar.myValue.mySkill[2].skillName + " is on cooldown.");
        } else {
            CharacterActionList.Add(ProvideTurnInput(SelectedChar, 2, 0));
            SelectedChar.SkillEnterCooldown(2);
            Skill2_CD.text = SelectedChar.SkillCurrentCD(2) + "/" + SelectedChar.SkillCD(2);
        }
    }

    public void PushSkill3ToList() {
        if (SelectedChar.SkillCurrentCD(3) < SelectedChar.SkillCD(3)) {
            Debug.Log(SelectedChar.myValue.mySkill[3].skillName + " is on cooldown.");
        } else {
            CharacterActionList.Add(ProvideTurnInput(SelectedChar, 3, 0));
            SelectedChar.SkillEnterCooldown(3);
            Skill3_CD.text = SelectedChar.SkillCurrentCD(3) + "/" + SelectedChar.SkillCD(3);
        }
    }

    public void PushSkill4ToList() {
        if (SelectedChar.SkillCurrentCD(4) < SelectedChar.SkillCD(4)) {
            Debug.Log(SelectedChar.myValue.mySkill[4].skillName + " is on cooldown.");
        } else {
            CharacterActionList.Add(ProvideTurnInput(SelectedChar, 4, 0));
            SelectedChar.SkillEnterCooldown(4);
            Skill4_CD.text = SelectedChar.SkillCurrentCD(4) + "/" + SelectedChar.SkillCD(4);
        }
    }

    public bool CharsAreDead() {
        bool deadCheck = true;
        for (int i = 0; i < playerParty.Count; i++) {
            if (playerParty[i].GetComponent<HeroStateMachine>().currentState == HeroStateMachine.State.DEAD) {
                deadCheck &= true;
            } else deadCheck &= false;
        }
        return deadCheck;
    }

    public bool EnemiesAreDead() {
        bool deadCheck = true;
        for (int i = 0; i < myEnemy.Count; i++) {
            if (myEnemy[i].GetComponent<EnemyStateMachine>().currentState == EnemyStateMachine.State.DEAD) {
                deadCheck &= true;
            } else deadCheck &= false;
        }
        return deadCheck;
    }
}
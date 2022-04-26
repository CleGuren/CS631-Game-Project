using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, VICTORIOUS, DEFEAT }

    //GameObjects
    public List<HandleTurn> ActionList = new List<HandleTurn>();
    public List<GameObject> playerParty = new List<GameObject>();
    public List<GameObject> myEnemy = new List<GameObject>();
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
    
    //Character Panel
    private GameObject CharacterActionBox;
    private Text CharNameText;
    private Text CharLevel;
    private Text HP_Value;
    private Text Skill1_CD;
    private Text Skill2_CD;
    private Text Skill3_CD;
    private Text Skill4_CD;
    private Image CharPortrait;
    private Image HP_Bar;
    private Button Skill1;
    private Button Skill2;
    private Button Skill3;
    private Button Skill4;
    
    //Conditional States
    private BattleState curr_state;
    private bool playerTurn;
    private bool triggerUI;
    public bool PlayerTurn {
        get { return playerTurn; }
        set { playerTurn = value; }
    } 
    
    public void Awake() {
        CharacterActionBox = GameObject.Find("Character Action Box");
        CharPortrait = GameObject.Find("Character Portrait").GetComponent<Image>();
        CharNameText = GameObject.Find("Character Name").GetComponent<Text>();
        CharLevel = GameObject.Find("Character Level").GetComponent<Text>();
        HP_Bar = GameObject.Find("Character HP Bar").GetComponent<Image>();
        HP_Value = GameObject.Find("HP Value").GetComponent<Text>();
        Skill1 = GameObject.Find("Skill 1").GetComponent<Button>();
        Skill2 = GameObject.Find("Skill 2").GetComponent<Button>();
        Skill3 = GameObject.Find("Skill 3").GetComponent<Button>();
        Skill4 = GameObject.Find("Skill 4").GetComponent<Button>();
        Skill1_CD = GameObject.Find("Skill 1 CD").GetComponent<Text>();
        Skill2_CD = GameObject.Find("Skill 2 CD").GetComponent<Text>();
        Skill3_CD = GameObject.Find("Skill 3 CD").GetComponent<Text>();
        Skill4_CD = GameObject.Find("Skill 4 CD").GetComponent<Text>();
        CharacterActionBox.SetActive(false);
    }

    void Start()
    {
        curr_state = BattleState.START;
        playerTurn = true;
        triggerUI = false;
    }

    void Update() {
        switch(curr_state) {
            case(BattleState.START) : 
                SpawnEntities();
                playerParty.AddRange(GameObject.FindGameObjectsWithTag("Character"));
                myEnemy.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
                curr_state = BattleState.PLAYERTURN;
                break;
            case(BattleState.PLAYERTURN) : 
                if (triggerUI) { 
                    CharacterActionBox.SetActive(true);
                }
                if (!playerTurn) {
                    triggerUI = false;
                    CharacterActionBox.SetActive(false);
                    curr_state = BattleState.ENEMYTURN;
                }
                break;
            case(BattleState.ENEMYTURN) :
                //enemy perform actions
                Debug.Log("Enemy Attacking");
                if (playerTurn) {
                    curr_state = BattleState.PLAYERTURN;
                }
                break;
            case(BattleState.VICTORIOUS) : 

                break;
            case(BattleState.DEFEAT) : 
                break;
        }
    }

    void SpawnEntities() {
        Instantiate(Character1Prefab, Character1Pos);
        Instantiate(Character2Prefab, Character2Pos);
        Instantiate(Character3Prefab, Character3Pos);
        Instantiate(Character4Prefab, Character4Pos);
        Instantiate(Enemy1Prefab, Enemy1Pos);
    }

    public void CollectActions(HandleTurn input) {
        ActionList.Add(input);
    }

    public void TurnProgress() {
        playerTurn = false;
    }

    public void ToPlayerturn() {
        curr_state = BattleState.PLAYERTURN;
    }

    // public void DisplayCharInformation(HeroBase CharInfo) {
    //     playerTurn = true;
    //     CharNameText.text = CharInfo.charName;
    //     CharLevel.text = "Lv." + CharInfo.level;
    //     CharPortrait.sprite = CharInfo.charPortrait;
    //     HP_Bar.transform.localScale = new Vector3(Mathf.Clamp(CharInfo.currentHP/CharInfo.maxHP, 0, 1), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);
    //     HP_Value.text = CharInfo.currentHP + "/" + CharInfo.maxHP;
    //     Skill1.image.sprite = CharInfo.skill1_img;
    //     Skill2.image.sprite = CharInfo.skill2_img;
    //     Skill3.image.sprite = CharInfo.skill3_img;
    //     Skill4.image.sprite = CharInfo.skill4_img;
    //     Skill1_CD.text = (CharInfo.mySkill.S1BaseCD - 2) + "/" + CharInfo.skill1_cd;
    //     Skill2_CD.text = (CharInfo.skill2_cd - 1) + "/" + CharInfo.skill2_cd;
    //     Skill3_CD.text = (CharInfo.skill3_cd - 1) + "/" + CharInfo.skill3_cd;
    //     Skill4_CD.text = (CharInfo.skill4_cd - 1) + "/" + CharInfo.skill4_cd;
    // }

    public void DisplayCharInformation(HeroStateMachine CharInfo) {
        triggerUI = true;
        CharNameText.text = CharInfo.myValue.charName;
        CharLevel.text = "Lv." + CharInfo.myValue.level;
        CharPortrait.sprite = CharInfo.myValue.charPortrait;
        HP_Bar.transform.localScale = new Vector3(Mathf.Clamp(CharInfo.myValue.currentHP/CharInfo.myValue.maxHP, 0, 1), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);
        HP_Value.text = CharInfo.myValue.currentHP + "/" + CharInfo.myValue.maxHP;
        Skill1.image.sprite = CharInfo.myValue.skill1_img;
        Skill2.image.sprite = CharInfo.myValue.skill2_img;
        Skill3.image.sprite = CharInfo.myValue.skill3_img;
        Skill4.image.sprite = CharInfo.myValue.skill4_img;
        Skill1_CD.text = (CharInfo.myValue.mySkill.S1BaseCD - 2) + "/" + CharInfo.myValue.skill1_cd;
        Skill2_CD.text = (CharInfo.myValue.skill2_cd - 1) + "/" + CharInfo.myValue.skill2_cd;
        Skill3_CD.text = (CharInfo.myValue.skill3_cd - 1) + "/" + CharInfo.myValue.skill3_cd;
        Skill4_CD.text = (CharInfo.myValue.skill4_cd - 1) + "/" + CharInfo.myValue.skill4_cd;
    }
}
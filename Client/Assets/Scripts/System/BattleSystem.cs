using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, VICTORIOUS, DEFEAT }
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
    private BattleState state;
    private bool moretest;
    
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
        state = BattleState.START;
        moretest = false;
    }

    void Update() {
        switch(state) {
            case(BattleState.START) : 
                SpawnEntities();
                state = BattleState.PLAYERTURN;
                break;
            case(BattleState.PLAYERTURN) : 
                if (moretest) { 
                    CharacterActionBox.SetActive(true);
                }
                break;
            case(BattleState.ENEMYTURN) : 
                if (moretest) {
                    CharacterActionBox.SetActive(true);
                }
                if (!moretest) {
                    CharacterActionBox.SetActive(false);
                }
                break;
            case(BattleState.VICTORIOUS) : 

                break;
            case(BattleState.DEFEAT) : 
                break;
        }
    }

    void SpawnEntities() {
        GameObject Temp = Instantiate(Character1Prefab, Character1Pos);
        Instantiate(Character2Prefab, Character2Pos);
        Instantiate(Character3Prefab, Character3Pos);
        Instantiate(Character4Prefab, Character4Pos);
        Instantiate(Enemy1Prefab, Enemy1Pos);
    }

    public void SetTrue() {
        moretest = true;
    }

    public void SetFalse() {
        moretest = false;
    }

    public void DisplayCharInformation(HeroBase CharInfo) {
        SetTrue();
        CharNameText.text = CharInfo.charName;
        CharLevel.text = "Lv." + CharInfo.level;
        CharPortrait.sprite = CharInfo.charPortrait;
        HP_Bar.transform.localScale = new Vector3(Mathf.Clamp(CharInfo.currentHP/CharInfo.maxHP, 0, 1), HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);
        HP_Value.text = CharInfo.currentHP + "/" + CharInfo.maxHP;
        Skill1.image.sprite = CharInfo.skill1_img;
        Skill2.image.sprite = CharInfo.skill2_img;
        Skill3.image.sprite = CharInfo.skill3_img;
        Skill4.image.sprite = CharInfo.skill4_img;
        Skill1_CD.text = (CharInfo.skill1_cd - 1) + "/" + CharInfo.skill1_cd;
        Skill2_CD.text = (CharInfo.skill2_cd - 1) + "/" + CharInfo.skill2_cd;
        Skill3_CD.text = (CharInfo.skill3_cd - 1) + "/" + CharInfo.skill3_cd;
        Skill4_CD.text = (CharInfo.skill4_cd - 1) + "/" + CharInfo.skill4_cd;
        /*cur_cooldown = curr_cooldown + Time.deltaTime;
        **float calc_cd = curr_cooldown / max_cooldown;
        **Progressbar.transform.localScale = new Vector3(Mathf.clamp(calc_cd, 0, 1), Progressbar.transform.localScale.y, Progressbar.transform.localScale.z);*/
    }
}

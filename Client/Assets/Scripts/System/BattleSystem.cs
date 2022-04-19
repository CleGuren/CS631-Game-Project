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
    public Text CharNameText;
    public Button AttackButton;
    public Button NoButton;
    private BattleState state;
    private List<GameObject> Party = new List<GameObject>();
    private HeroStateMachine bleh;
    private GameObject CharacterActionBox;
    private bool moretest;
    
    void Start()
    {
        state = BattleState.START;
        moretest = false;
        CharacterActionBox = GameObject.Find("Character Action Box");
        CharacterActionBox.SetActive(false);
    }

    void Update() {
        switch(state) {
            case(BattleState.START) : 
                SpawnEntities();
                // SetupCharacterPanel();
                state = BattleState.PLAYERTURN;
                break;
            case(BattleState.PLAYERTURN) : 
                Debug.Log("Player's turn!");
                if (moretest) { 
                    CharacterActionBox.SetActive(true);
                    SetupCharacterPanel();
                    state = BattleState.ENEMYTURN;
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
        GameObject Temp = Instantiate(Character1Prefab, Character1Pos) as GameObject;
        Temp.name = "Char One";
        bleh = Temp.GetComponent<HeroStateMachine>();
        Party.Add(Temp);
        Instantiate(Character2Prefab, Character2Pos);
        Instantiate(Character3Prefab, Character3Pos);
        Instantiate(Character4Prefab, Character4Pos);
        Instantiate(Enemy1Prefab, Enemy1Pos);
    }

    void SetupCharacterPanel() {
        CharNameText.text = bleh.myValue.charName;
        state = BattleState.PLAYERTURN;
    }

    public void SetTrue() {
        moretest = true;
    }

    public void SetFalse() {
        moretest = false;
    }
}

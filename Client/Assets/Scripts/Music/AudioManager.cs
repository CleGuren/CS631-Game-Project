using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WwiseGameState
{
    Combat_State, Explore_State, Gameplay_None
};

public enum WwiseMusicState
{
    Boss_Phase_1_Music_State, Boss_Phase_2_Music_State, Combat_Music_State, Defeat_Music_State, 
    Town_Music_State, None, Training_Ground_Music_State, Victory_Music_State
};

public enum WwisePauseState
{
    None, Pause_State, Unpause_State
};

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private bool bIsInitialized = false;
    
    [Header("Soundbanks")]
    [SerializeField] private List<AK.Wwise.Bank> Soundbanks;
    
    // Gameplay General State Events
    [Header ("General Event Gameplay States")]
    [SerializeField] private AK.Wwise.Event Gameplay_Set_State_Combat_State;
    [SerializeField] private AK.Wwise.Event Gameplay_Set_State_Explore_State;
    
    [Header ("General Event Pause States")]
    [SerializeField] private AK.Wwise.Event Gameplay_Set_State_Pause_State;
    [SerializeField] private AK.Wwise.Event Gameplay_Set_State_Unpause_State;
    
    // Music Events
    [Header ("Play Events")]
    [SerializeField] private AK.Wwise.Event Play_Gameplay_Music;
    [SerializeField] private AK.Wwise.Event Play_Main_Menu_Music;
    [SerializeField] private AK.Wwise.Event Check_Game_State;   // audio
    
    [Header ("States Events")]
    [SerializeField] private AK.Wwise.Event Set_State_Boss_Phase_1_Music_State;
    [SerializeField] private AK.Wwise.Event Set_State_Boss_Phase_2_Music_State;
    [SerializeField] private AK.Wwise.Event Set_State_Combat_Music_State;
    [SerializeField] private AK.Wwise.Event Set_State_Defeat_Music_State;
    [SerializeField] private AK.Wwise.Event Set_State_Town_Music_State;
    [SerializeField] private AK.Wwise.Event Set_State_Training_Ground_Music_State;
    [SerializeField] private AK.Wwise.Event Set_State_Victory_Music_State;
    
    [Header ("Stop Events")]
    [SerializeField] private AK.Wwise.Event Stop_Gameplay_Music;
    [SerializeField] private AK.Wwise.Event Stop_Main_Menu_Music;
    
    // SFX Events
    [Header ("UI Events")]
    [SerializeField] private AK.Wwise.Event Play_SFX_UI_Back;
    [SerializeField] private AK.Wwise.Event Play_SFX_UI_Confirm;
    [SerializeField] private AK.Wwise.Event Play_SFX_UI_Select;
    
    
    
    
    
    
    
    
    // Game State
    [Header ("Game State Variables")]
    [SerializeField] private AK.Wwise.State Gameplay_Combat_State;
    [SerializeField] private AK.Wwise.State Gameplay_Explore_State;
    [SerializeField] private AK.Wwise.State Gameplay_None;

    private WwiseGameState currentGameState;
    
    // Game Music
    [Header ("Music State Variables")]
    [SerializeField] private AK.Wwise.State Music_Boss_Phase_1_Music_State;
    [SerializeField] private AK.Wwise.State Music_Boss_Phase_2_Music_State;
    [SerializeField] private AK.Wwise.State Music_Combat_Music_State;
    [SerializeField] private AK.Wwise.State Music_Defeat_Music_State;
    [SerializeField] private AK.Wwise.State Music_None;
    [SerializeField] private AK.Wwise.State Music_Town_Music_State;
    [SerializeField] private AK.Wwise.State Music_Training_Ground_Music_State;
    [SerializeField] private AK.Wwise.State Music_Victory_Music_State;
    
    private WwiseMusicState currentMusicState;
    
    // Game Pause
    [Header ("Pause State Variables")]
    [SerializeField] private AK.Wwise.State Pause_None;
    [SerializeField] private AK.Wwise.State Pause_Pause_State;
    [SerializeField] private AK.Wwise.State Pause_Unpause_State;
    
    private WwisePauseState currentPauseState;

    private void Awake()
    {
        Initialize(); // initialize the soundbanks check
    }
    
        
    void Start()
    {
        if (
            SceneManager.GetActiveScene().name != "LoginScene"
            && SceneManager.GetActiveScene().name != "RegistrationScene"
            && SceneManager.GetActiveScene().name != "MenuScene"
            && SceneManager.GetActiveScene().name != "OpeningScene"
            && SceneManager.GetActiveScene().name != "OptionsScene"
        )
        {
            AkSoundEngine.StopAll();
        }
        
        SetWiseGameState(WwiseGameState.Explore_State);
        SetWiseMusicState(WwiseMusicState.Town_Music_State);
        SetWwisePausedState(WwisePauseState.Unpause_State);
    }

    void Update()
    {
        
    }

    void Initialize()
    {
        // Singleton logic
        if (Instance == null)
        {
            // instance created
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            // existing instance; destroy itself
            Debug.LogWarning("AudioManager already exists! Destroying new instance.");
            Destroy(this);
        }

        if (!bIsInitialized)    // if the soundbanks haven't been initialized
        {
            loadSoundBanks();
        }
        
        // set the enums to be off by default
        SetWiseGameState(WwiseGameState.Gameplay_None);
        SetWiseMusicState(WwiseMusicState.None);
        SetWwisePausedState(WwisePauseState.None);
        
        bIsInitialized = true;
    }
    
    void loadSoundBanks()
    {
        if (Soundbanks.Count > 0)
        {
            foreach (AK.Wwise.Bank bank in Soundbanks) // for each of the banks in the list
            {
                bank.Load();
                    
                Debug.Log("Soundbanks have been loaded.");
            }
        }
        else
        {
            Debug.LogError("Soundbanks list is empty. Are the banks assigned to the AudioManager?");
        }
    }
    // setup a switch - checks the current enum and switches the state to load
    void SetWiseGameState(WwiseGameState gameState)
    {
        if (gameState == currentGameState)
        {
            Debug.Log("GameState is already " + gameState + ".");
            return;
        }
        switch (gameState)
        {
            case(WwiseGameState.Combat_State):
                Gameplay_Combat_State.SetValue();
                break;
            case(WwiseGameState.Explore_State):
                Gameplay_Explore_State.SetValue();
                break;
            case(WwiseGameState.Gameplay_None):
                Gameplay_None.SetValue();
                break;
        }
        
        Debug.Log("New Wwise GameState: " + gameState + ".");
        currentGameState = gameState;
    }
    
    void SetWiseMusicState(WwiseMusicState musicState)
    {
        if (musicState == currentMusicState)
        {
            Debug.Log("GameState is already " + musicState + ".");
            return;
        }
        switch (musicState)
        {
            case(WwiseMusicState.None):
                Music_None.SetValue();
                break;
            case(WwiseMusicState.Combat_Music_State):
                Music_Combat_Music_State.SetValue();
                break;
            case(WwiseMusicState.Defeat_Music_State):
                Music_Defeat_Music_State.SetValue();
                break;
            case(WwiseMusicState.Town_Music_State):
                Music_Town_Music_State.SetValue();
                break;
            case(WwiseMusicState.Boss_Phase_1_Music_State):
                Music_Boss_Phase_1_Music_State.SetValue();
                break;
            case(WwiseMusicState.Boss_Phase_2_Music_State):
                Music_Boss_Phase_2_Music_State.SetValue();
                break;
            case(WwiseMusicState.Training_Ground_Music_State):
                Music_Training_Ground_Music_State.SetValue();
                break;
            case(WwiseMusicState.Victory_Music_State):
                Music_Victory_Music_State.SetValue();
                break;
        }
        Debug.Log("New Wwise MusicState: " + musicState + ".");
        currentMusicState = musicState;
    }
    
    void SetWwisePausedState(WwisePauseState pauseState)
    {
        if (pauseState == currentPauseState)
        {
            Debug.Log("GameState is already " + pauseState + ".");
            return;
        }
        
        switch (pauseState)
        {
            case(WwisePauseState.None):
                Pause_None.SetValue();
                break;
            case(WwisePauseState.Pause_State):
                Pause_Pause_State.SetValue();
                break;
            case(WwisePauseState.Unpause_State):
                Pause_Unpause_State.SetValue();
                break;
        }
        Debug.Log("New Wwise PauseState: " + pauseState + ".");
        currentPauseState = pauseState;
    }
}


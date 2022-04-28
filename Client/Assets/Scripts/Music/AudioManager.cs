using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private bool bIsInitialized = false;
    
    [Header("Soundbanks")]
    [SerializeField] private List<AK.Wwise.Bank> Soundbanks;
    
    // Game State
    [Header ("Game State Variables")]
    [SerializeField] private AK.Wwise.State Gameplay_Combat_State;
    [SerializeField] private AK.Wwise.State Gameplay_Explore_State;
    [SerializeField] private AK.Wwise.State Gameplay_None;
    
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
    
    // Game Pause
    [Header ("Pause State Variables")]
    [SerializeField] private AK.Wwise.State Pause_None;
    [SerializeField] private AK.Wwise.State Pause_Pause_State;
    [SerializeField] private AK.Wwise.State Pause_Unpause_State;

    private void Awake()
    {
        Initialize(); // initialize the soundbanks check
    }
    
        
    void Start()
    {
        
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
}


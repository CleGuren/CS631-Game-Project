using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
    {
        private bool useNetwork;
        private NetworkManager networkManager;

        public static AK.Wwise.Event startMainMusicEvent;
        public static AK.Wwise.Event startTownHubMusicEvent;
        public static AK.Wwise.Event startBattleEvent;
        public static AK.Wwise.Event startTutorialEvent
            ;
    }

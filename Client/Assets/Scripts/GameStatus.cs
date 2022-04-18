// using System;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEditor;
// using UnityEngine.UI;
//
// public class GameStatus : MonoBehaviour
// {
//     private GameObject mainObject;
//     private short status;
//     private string name = "";
//     private float time;
//     private bool win;
//     // start button
//     public Button StartButton;
//
//     private MessageQueue msgQueue;
//     private ConnectionManager cManager;
//     
//     void Awake() {
//         mainObject = GameObject.Find("Network Manager");
//         cManager = mainObject.GetComponent<ConnectionManager>();
//         msgQueue = mainObject.GetComponent<MessageQueue> ();
//         msgQueue.AddCallback(Constants.SMSG_LOGIN, GameStatusResponse);
//     }
//
//     private void Start()
//     {
//         StartButton.onClick.AddListener(() =>
//         {
//             
//         });
//     }
// }

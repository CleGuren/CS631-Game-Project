using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private NetworkManager networkManager;
    private MessageQueue msgQueue;

    private void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_SPAWN_PLAYER, OnResponseSpawnPlayer);
    }

    private void OnDestroy()
    {
        msgQueue.RemoveCallback(Constants.SMSG_SPAWN_PLAYER);
    }

    public void testSpawnPlayerRequest()
    {
        MakeRequestSpawnPlayer(5, 5);
    }

    public void MakeRequestSpawnPlayer(int x, int y)
    {
        networkManager.RequestSpawnPlayer(x, y);
    }

    public void OnResponseSpawnPlayer(ExtendedEventArgs eventArgs)
    {
        ResponseSpawnPlayerEventArgs args = eventArgs as ResponseSpawnPlayerEventArgs;

        // Spawn Player
        Debug.LogFormat("Response Spawn Player Result: ( %n, %s, %n, %n )");

    }
}
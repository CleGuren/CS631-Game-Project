using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private NetworkManager networkManager;
    private MessageQueue msgQueue;

    private void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_SPAWN_PLAYER, OnResponseSpawnPlayer);

        MakeRequestSpawnPlayer(spawnPoint.position.x, spawnPoint.position.y);
    }

    private void OnDestroy()
    {
        msgQueue.RemoveCallback(Constants.SMSG_SPAWN_PLAYER);
    }

    public void MakeRequestSpawnPlayer(float x, float y)
    {
        networkManager.RequestSpawnPlayer(x, y);
    }

    public void OnResponseSpawnPlayer(ExtendedEventArgs eventArgs)
    {
        ResponseSpawnPlayerEventArgs args = eventArgs as ResponseSpawnPlayerEventArgs;

        // Spawn Player
        Debug.LogFormat("Response Spawn Player Result: ( {0}, {1}, {2}, {3} )", args.user_id, args.username, args.x, args.y);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject playerPrefab;
    private NetworkManager networkManager;
    private MessageQueue msgQueue;

    private void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_SPAWN_PLAYER, OnResponseSpawnPlayer);

        // Spawn Self
        MakeRequestSpawnPlayer(spawnPoint.position.x, spawnPoint.position.y);
        // Spawn Other
    }

    private void OnDestroy()
    {
        msgQueue.RemoveCallback(Constants.SMSG_SPAWN_PLAYER);
    }

    // Player Spawning
    private void SpawnPlayer(int user_id, string username)
    {
        GameObject newPlayer = GameObject.Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);

        // Camera Setting Check
        Player newPlayerScript = newPlayer.GetComponent<Player>();
        newPlayerScript.playerID = user_id;
        newPlayerScript.username = username;
        newPlayerScript.SetCamera();
    }

    // Network
    public void MakeRequestSpawnPlayer(float x, float y)
    {
        networkManager.RequestSpawnPlayer(x, y);
    }

    public void OnResponseSpawnPlayer(ExtendedEventArgs eventArgs)
    {
        ResponseSpawnPlayerEventArgs args = eventArgs as ResponseSpawnPlayerEventArgs;

        // Spawn Player
        Debug.Log("Shouldn't be here");
        SpawnPlayer(args.user_id, args.username);
        Debug.LogFormat("Response Spawn Player Result: ( {0}, {1}, {2}, {3} )", args.user_id, args.username, args.x, args.y);


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject playerPrefab;
    private NetworkManager networkManager;
    private MessageQueue msgQueue;
    private List<Player> players = new List<Player>();

    private void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_SPAWN_PLAYER, OnResponseSpawnPlayer);
        msgQueue.AddCallback(Constants.SMSG_DESPAWN_PLAYER, OnResponseDespawnPlayer);

        // Spawn Self
        MakeRequestSpawnPlayer(spawnPoint.position.x, spawnPoint.position.y);
        // Spawn Other
        MakeRequestSpawnOtherPlayer();
    }

    private void OnDestroy()
    {
        MakeRequestDespawnPlayer();
        msgQueue.RemoveCallback(Constants.SMSG_SPAWN_PLAYER);
        msgQueue.RemoveCallback(Constants.SMSG_DESPAWN_PLAYER);
    }

    private void OnApplicationQuit() {
        MakeRequestDespawnPlayer();
    }

    // Player Spawning
    private void SpawnPlayer(int user_id, string username)
    {
        // Don't spawn if there's duplicate
        foreach (var p in players)
        {
            if (p.playerID == user_id)
            {
                return;
            }
        }

        GameObject newPlayer = GameObject.Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        players.Add(newPlayer.GetComponent<Player>());
        // Camera Setting Check
        Player newPlayerScript = newPlayer.GetComponent<Player>();
        newPlayerScript.playerID = user_id;
        newPlayerScript.username = username;
        newPlayerScript.SetCamera();
    }

    private void DespawnPlayer(int user_id)
    {
        for (int i = 0; i < players.Count; i++)
        {
            var p = players[i];

            if (p.playerID == user_id && p.playerID != Constants.USER_ID)
            {
                Debug.Log("Destroyed");
                var removedPlayer = players[i];
                players.RemoveAt(i);
                removedPlayer.DespawnPlayer();
            }
        }
    }

    // Network
    public void MakeRequestSpawnPlayer(float x, float y)
    {
        networkManager.RequestSpawnPlayer(x, y);
    }

    public void MakeRequestSpawnOtherPlayer()
    {
        networkManager.RequestSpawnOtherPlayers();
    }

    public void MakeRequestDespawnPlayer()
    {
        networkManager.RequestDespawnPlayer();
    }

    public void OnResponseSpawnPlayer(ExtendedEventArgs eventArgs)
    {
        ResponseSpawnPlayerEventArgs args = eventArgs as ResponseSpawnPlayerEventArgs;

        // Spawn Player
        SpawnPlayer(args.user_id, args.username);
        Debug.LogFormat("Response Spawn Player Result: ( {0}, {1}, {2}, {3} )", args.user_id, args.username, args.x, args.y);
    }

    public void OnResponseDespawnPlayer(ExtendedEventArgs eventArgs)
    {
        ResponseDespawnPlayerEventArgs args = eventArgs as ResponseDespawnPlayerEventArgs;

        // Spawn Player
        DespawnPlayer(args.user_id);
    }
}
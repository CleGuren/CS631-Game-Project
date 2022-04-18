using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSpawnOtherPlayers : NetworkRequest
{
    public RequestSpawnOtherPlayers()
    {
        request_id = Constants.CMSG_SPAWN_OTHER_PLAYERS;
    }

    public void send()
    {
        packet = new GamePacket(request_id);
    }
}

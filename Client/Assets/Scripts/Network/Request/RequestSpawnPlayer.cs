using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSpawnPlayer : NetworkRequest
{
    public RequestSpawnPlayer()
    {
        request_id = Constants.CMSG_SPAWN_PLAYER;
    }

    public void send(int x, int y)
    {
        packet = new GamePacket(request_id);
        packet.addInt32(x);
        packet.addInt32(y);
    }
}
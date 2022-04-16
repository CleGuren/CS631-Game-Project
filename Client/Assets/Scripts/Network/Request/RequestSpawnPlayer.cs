using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSpawnPlayer : NetworkRequest
{
    public RequestSpawnPlayer()
    {
        request_id = Constants.CMSG_SPAWN_PLAYER;
    }

    public void send(float x, float y)
    {
        packet = new GamePacket(request_id);
        packet.addFloat32(x);
        packet.addFloat32(y);
    }
}
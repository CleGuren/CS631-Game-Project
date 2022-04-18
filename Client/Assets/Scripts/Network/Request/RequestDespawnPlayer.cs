using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDespawnPlayer : NetworkRequest
{
    public RequestDespawnPlayer()
    {
        request_id = Constants.CMSG_DESPAWN_PLAYER;
    }

    public void send()
    {
        packet = new GamePacket(request_id);
    }
}
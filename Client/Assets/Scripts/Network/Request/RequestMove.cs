using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class RequestMove : NetworkRequest
{
    public RequestMove()
    {
        request_id = Constants.CMSG_MOVE;
    }

    public void send(int id, float x, float y)
    {
        packet = new GamePacket(request_id);
       // packet.addString(Constants.CLIENT_VERSION);
        packet.addInt32(id);
        packet.addFloat32(x);
        packet.addFloat32(y);
    }
}

using UnityEngine;
using System;

public class GameStatusRequest : NetworkRequest
    {
        public GameStatusRequest()
        {
            request_id = Constants.CMSG_STATUS;
        }

        public void send(string name, float time, bool win)
        {
            packet = new GamePacket(request_id);
            packet.addString(name);
            packet.addFloat32(time);
            packet.addBool(win);
        }
    }
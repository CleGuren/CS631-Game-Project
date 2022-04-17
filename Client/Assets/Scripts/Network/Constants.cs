using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // Constants
    public static readonly string CLIENT_VERSION = "1.00";
    public static readonly string REMOTE_HOST = "localhost";
    public static readonly int REMOTE_PORT = 1729;

    // Request (1xx) + Response (2xx)
    public static readonly short CMSG_HEARTBEAT = 111;
    public static readonly short CMSG_LOGIN = 113;
    public static readonly short SMSG_LOGIN = 216;
    public static readonly short CMSG_REGISTER = 114;
    public static readonly short SMSG_REGISTER = 218;
    public static readonly short CMSG_NETWORK = 115;
    public static readonly short SMSG_NETWORK = 219;
    public static readonly short CMSG_STATUS = 116;
    public static readonly short SMSG_STATUS = 220;

    public static readonly short CMSG_SPAWN_PLAYER = 150;
    public static readonly short SMSG_SPAWN_PLAYER = 250;
    public static readonly short CMSG_SPAWN_OTHER_PLAYERS = 151;

    public static int USER_ID = -1;
    public static int OP_ID = -1;
}

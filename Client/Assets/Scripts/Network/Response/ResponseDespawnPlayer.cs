using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDespawnPlayerEventArgs : ExtendedEventArgs
{
    public int user_id { get; set; }

    public ResponseDespawnPlayerEventArgs()
    {
        event_id = Constants.SMSG_DESPAWN_PLAYER;
    }
}

public class ResponseDespawnPlayer : NetworkResponse
{
    private int user_id;

    public ResponseDespawnPlayer() { }

    public override void parse()
    {
        user_id = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseDespawnPlayerEventArgs args = new ResponseDespawnPlayerEventArgs
        {
            user_id = user_id
        };

        return args;
    }
}
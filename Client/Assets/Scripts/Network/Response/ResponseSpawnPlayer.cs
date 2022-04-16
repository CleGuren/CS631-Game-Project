using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseSpawnPlayerEventArgs : ExtendedEventArgs
{
    public int user_id { get; set; }
    public string username { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public ResponseSpawnPlayerEventArgs()
    {
        event_id = Constants.SMSG_SPAWN_PLAYER;
    }
}

public class ResponseSpawnPlayer : NetworkResponse
{
    private int user_id;
    private string username;
    private int x;
    private int y;

    public ResponseSpawnPlayer() { }

    public override void parse()
    {
        user_id = DataReader.ReadInt(dataStream);
        username = DataReader.ReadString(dataStream);
        x = DataReader.ReadInt(dataStream);
        y = DataReader.ReadInt(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseSpawnPlayerEventArgs args = new ResponseSpawnPlayerEventArgs
        {
            user_id = user_id,
            username = username,
            x = x,
            y = y
        };

        return args;
    }
}
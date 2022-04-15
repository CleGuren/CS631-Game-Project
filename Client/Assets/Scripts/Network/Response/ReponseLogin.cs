using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseLoginEventArgs : ExtendedEventArgs
{
    public short status // 0 = success
    { get; set; }
    public int player_id  
    { get; set; }
    public string username // username of character
    { get; set; }
    
    public ResponseLoginEventArgs()
    {
        event_id = Constants.SMSG_LOGIN;
    }
}

public class ResponseLogin : NetworkResponse
{
    private short status;
    private int player_id;
    private string username;

    public ResponseLogin()
    {
    }

    public override void parse()
    {
        status = DataReader.ReadShort(dataStream);
        if (status == 0)
        {
            username = DataReader.ReadString(dataStream);
            player_id = DataReader.ReadInt(dataStream);
        }
    }

    public override ExtendedEventArgs process()
    {
        ResponseLoginEventArgs args = new ResponseLoginEventArgs
        {
            status = status
        };
        if (status == 0)
        {
            args = new ResponseLoginEventArgs();
            args.status = status;
            args.username = username;
            args.player_id = player_id;
        }
        return args;
    }
}
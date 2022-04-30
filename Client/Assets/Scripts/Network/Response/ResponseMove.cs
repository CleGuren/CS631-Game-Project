using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseMoveEventArgs : ExtendedEventArgs
{
    public short status // 0 = success
    { get; set; }
    public int player_id  
    { get; set; }
    public float x
    { get; set; }
    public float y
    { get; set; }
    
    public ResponseMoveEventArgs()
    {
        event_id = Constants.SMSG_MOVE;
    }
}

public class ResponseMove : NetworkResponse
{
    // private short status;
    private int player_id;
    private float x;
    private float y;

    public ResponseMove()
    {
    }

    public override void parse()
    {
        // status = DataReader.ReadShort(dataStream);
        // if (status == 0)
        // {
        //     player_id = DataReader.ReadInt(dataStream);
        //     x = DataReader.ReadFloat(dataStream);
        //     y = DataReader.ReadFloat(dataStream);
        // }
        player_id = DataReader.ReadInt(dataStream);
        x = DataReader.ReadFloat(dataStream);
        y = DataReader.ReadFloat(dataStream);
    }

    public override ExtendedEventArgs process()
    {
        ResponseMoveEventArgs args = new ResponseMoveEventArgs
        {
            // status = status
        };
        // if (status == 0)
        // {
        //     args = new ResponseMoveEventArgs();
        //     args.status = status;
        //     args.player_id = player_id;
        //     args.x = x;
        //     args.y = y;
        // }
        args = new ResponseMoveEventArgs();
        args.player_id = player_id;
        args.x = x;
        args.y = y;
        return args;
    }
}
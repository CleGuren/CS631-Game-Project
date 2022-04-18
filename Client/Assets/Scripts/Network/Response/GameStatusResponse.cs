using UnityEngine;
using System;

public class GameStatusResponseEventArgs : ExtendedEventArgs
{
    public short status { get; set; }
    public string name { get; set; }
    public float time { get; set; }
    public bool win { get; set; }

    public GameStatusResponseEventArgs()
    {
        event_id = Constants.SMSG_STATUS;
    }
}

public class GameStatusResponse : NetworkResponse
{
    private short status;
    private string name;
    private float time;
    private bool win;

    public GameStatusResponse()
    {
    }

    public override void parse()
    {
        status = DataReader.ReadShort(dataStream);
        if (status == 0)
        {
            name = DataReader.ReadString(dataStream);
            time = DataReader.ReadFloat(dataStream);
            win = DataReader.ReadBool(dataStream);
        }
    }

    public override ExtendedEventArgs process()
    {
        GameStatusResponseEventArgs args = new GameStatusResponseEventArgs
        {
            status = status
        };
        
        if (status == 0)
        {
            args = new GameStatusResponseEventArgs();
            args.status = status;
            args.name = name;
            args.time = time;
            args.win = win;
        }
        return args;
    }
}
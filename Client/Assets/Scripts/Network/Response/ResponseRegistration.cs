using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseRegistrationEventArgs : ExtendedEventArgs
{
    public short status // 0 = success
    {
        get;
        set;
    }
    public string username // username of character
    {
        get;
        set;
    }
    
    public ResponseRegistrationEventArgs()
    {
        event_id = Constants.SMSG_REGISTER;
    }
}

public class ResponseRegistration : NetworkResponse
{
    private short status;
    private string username;

    public ResponseRegistration()
    {
    }

    public override void parse()
    {
        status = DataReader.ReadShort(dataStream);
        if (status == 0)
        {
            username = DataReader.ReadString(dataStream);
        }
    }

    public override ExtendedEventArgs process()
    {
        ResponseRegistrationEventArgs args = null;
        if (status == 0)
        {
            args = new ResponseRegistrationEventArgs();
            args.status = status;
            args.username = username;
        }
        return args;
    }
}

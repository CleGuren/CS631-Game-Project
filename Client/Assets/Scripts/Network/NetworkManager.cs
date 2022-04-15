using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NetworkManager : MonoBehaviour
{
    private ConnectionManager cManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        gameObject.AddComponent<MessageQueue>();
        gameObject.AddComponent<ConnectionManager>();

        NetworkRequestTable.init();
        NetworkResponseTable.init();
    }

    private void Start()
    {
        cManager = GetComponent<ConnectionManager>();

        if (cManager)
        {
            cManager.setupSocket();
            StartCoroutine(RequestHeartbeat(.1f));
        }
    }
    
    // // login request
    // public bool SendLoginRequest()
    // {
    //     if (cManager && cManager.IsConnected())
    //     {
    //         RequestLogin loginRequest = new RequestLogin();
    //         loginRequest.send(req);  
    //         cManager.send(loginRequest);
    //         return true;
    //     }
    //     return false;
    // }
    
    // // register request
    // public bool SendLoginRequest()
    // {
    //     if (cManager && cManager.IsConnected())
    //     {
    //         Request
    //     }
    // }
    
    
    // check for heartbeat
    public IEnumerator RequestHeartbeat(float time)
    {
        yield return new WaitForSeconds(time);

        if (cManager)
        {
            RequestHeartbeat request = new RequestHeartbeat();
            request.send();
            cManager.send(request);
        }

        StartCoroutine(RequestHeartbeat(time));
    }
}
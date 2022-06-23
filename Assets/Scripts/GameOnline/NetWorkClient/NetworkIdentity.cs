using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkIdentity : MonoBehaviour
{
    [SerializeField]
    [GreyOut]
    private string id;
    [SerializeField]
    [GreyOut]
    private bool isControlling;
    private SocketIOComponent socket;
    public void Awake()
    {
        isControlling = false;
    }
    void Start()
    {

    }
    public void SetControllerID(string ID)
    {
        id = ID;
        isControlling = (NetworkClient.ClientID == ID) ? true : false;
        //Debug.Log(isControlling);
    }

    public void SetSocketReference(SocketIOComponent Socket)
    {
        socket = Socket;
    }
    public string GetID()
    {
        return id;
    }
    public bool IsControlling()
    {
        return isControlling;
    }
    public SocketIOComponent GetSocket()
    {
        return socket;
    }
    void Update()
    {

    }
}

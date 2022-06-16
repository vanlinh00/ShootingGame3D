using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NetworkIdentity))]
public class NetworkTransform : MonoBehaviour
{
    private Vector3 oldPostion;
    private NetworkIdentity networkIdentity;
    private Player _player;
    private float stillCounter = 0;
    void Start()
    {
        _player = new Player();
        networkIdentity = GetComponent<NetworkIdentity>();
        oldPostion = transform.position;

        if (!networkIdentity.IsControlling())
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (networkIdentity.IsControlling())
        {
            if (oldPostion != transform.position)
            {
                oldPostion = transform.position;
                stillCounter = 0;
                SendData();
            }
            else
            {
                stillCounter += Time.deltaTime;
                if (stillCounter >= 1)
                {
                    stillCounter = 0;
                    SendData();
                }
            }
        }
    }
    private void SendData()
    {
        _player.x = Mathf.Round(transform.position.x * 1000.0f) / 1000.0f;
        _player.z = Mathf.Round(transform.position.z * 1000.0f) / 1000.0f;
        networkIdentity.GetSocket().Emit("updatePosition", new JSONObject(JsonUtility.ToJson(_player)));
    }

}

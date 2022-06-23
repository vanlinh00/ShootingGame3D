using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NetworkIdentity1))]
public class NetworkTransform1 : MonoBehaviour
{
    private Vector3 oldPostion;
    private NetworkIdentity1 networkIdentity;
    private Player1 _player;
    private float stillCounter = 0;
    void Start()
    {
        _player = new Player1();
        networkIdentity = GetComponent<NetworkIdentity1>();
        oldPostion = transform.position;
        // flase thi
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

            // oldPostion = transform.position;

            // SendData();

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

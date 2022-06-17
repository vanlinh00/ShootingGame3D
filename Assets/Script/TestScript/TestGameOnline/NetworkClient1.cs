using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class NetworkClient1 : SocketIOComponent
{
    // Start is called before the first frame update
    [SerializeField] Transform NetworkContainer;
    private Dictionary<string, NetworkIdentity1> serverObjects;
    public static string ClientID { get; private set; }
    public override void Start()
    {
        base.Start();
        initalise();
        setUpEvent();

    }
    private void initalise()
    {
        serverObjects = new Dictionary<string, NetworkIdentity1>();
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    private void setUpEvent()
    {
        On("open", (E) =>
        {
            Debug.Log("connection made to the server");
        });

        On("dangki", (E) =>
        {
            ClientID = E.data["id"].ToString();
        });
        On("spawn", (E) =>
           {
               Debug.Log(E);
               string id = E.data["id"].ToString();
               GameObject _newPlayer = Instantiate(Resources.Load("Test/Player", typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
               _newPlayer.name = string.Format("Player({0})", id);
               NetworkIdentity1 ni = _newPlayer.GetComponent<NetworkIdentity1>();
               ni.SetControllerID(id);
               ni.SetSocketReference(this);
               serverObjects.Add(id, ni);

           });

        On("disconnected", (E) =>
             {
                 string id = E.data["id"].ToString();
                 GameObject go = serverObjects[id].gameObject;
                 Destroy(go);
                 serverObjects.Remove(id);
             });

        On("updatePosition", (E) =>
        {
            string id = E.data["id"].ToString();
            float x = E.data["position"]["x"].f;
            float z = E.data["position"]["z"].f;
            Debug.Log(x);
            NetworkIdentity1 ni = serverObjects[id];
            ni.transform.position = new Vector3(x, 0, z);
            Debug.Log(new Vector3(0, 0, 0));

        });

    }
}


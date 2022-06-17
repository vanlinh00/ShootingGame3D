using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using Cinemachine;

public class NetworkClient : SocketIOComponent
{
    // Start is called before the first frame update
    [SerializeField] Transform NetworkContainer;
    private Dictionary<string, NetworkIdentity> serverObjects;
    public static string ClientID { get; private set; }
    public override void Start()
    {
        base.Start();
        initalise();
        setUpEvent();

    }
    private void initalise()
    {
        serverObjects = new Dictionary<string, NetworkIdentity>();
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
        On("newplayer", (E) =>
           {
               //  Quaternion a = new Quaternion(0, 0, 0, 0);

               Debug.Log("vao ham spawn");
               string id = E.data["id"].ToString();
               GameObject _newPlayer = Instantiate(Resources.Load("Player", typeof(GameObject)), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;




               // CameraController.instance.CameraFLlowPlayer(PlayerCameraRoot);
               //  CameraController.instance.VrCamShootFLlowPlayer(PlayerCameraRoot);
               // _newPlayer.transform.SetParent(NetworkContainer);
               _newPlayer.name = string.Format("Player({0})", id);
               //_newPlayer.name = string.Format("Player");
               //  GameController.instance.SetListEnemy(true);
               NetworkIdentity ni = _newPlayer.GetComponent<NetworkIdentity>();
               ni.SetControllerID(id);
               ni.SetSocketReference(this);
               serverObjects.Add(id, ni);

               if (ClientID == id)
               {
                   GameObject PlayerCameraRoot = _newPlayer.transform.GetChild(0).gameObject;
                   CinemachineVirtualCamera _newCamera = Instantiate(Resources.Load("PlayerFollowCamera", typeof(CinemachineVirtualCamera)), new Vector3(0, 0, 0), Quaternion.identity) as CinemachineVirtualCamera;
                   _newCamera.Follow = PlayerCameraRoot.transform;
               }

           });

        On("disconnected", (E) =>
             {
                 string id = E.data["id"].ToString();
                 ///Debug.Log(id);

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
            NetworkIdentity ni = serverObjects[id];
            ni.transform.position = new Vector3(x, 0, z);
            Debug.Log(new Vector3(0, 0, 0));

        });

    }
}


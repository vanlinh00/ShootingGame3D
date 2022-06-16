using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField]
    GameObject _vrCamShoot;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerSniperCult(bool a)
    {
        _vrCamShoot.SetActive(a);
    }
}

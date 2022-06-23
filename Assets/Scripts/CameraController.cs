using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public CinemachineVirtualCamera _vrCamShoot;

    public CinemachineVirtualCamera PlayerFollowCamera;
    private void Awake()
    {

    }
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
        _vrCamShoot.gameObject.SetActive(a);
    }
    public void CameraFLlowPlayer(GameObject target)
    {
        PlayerFollowCamera.Follow = target.transform;
    }
    public void VrCamShootFLlowPlayer(GameObject target)
    {
        _vrCamShoot.Follow = target.transform;
    }
}

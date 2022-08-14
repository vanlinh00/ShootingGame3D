using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    [SerializeField] GameObject _vrCamShoot;
    [SerializeField] GameObject _playerFollowCamera;
    void Awake()
    {
        instance = this;

    }
    public void PlayerSniperCult(bool a)
    {
        _vrCamShoot.gameObject.SetActive(a);
    }
    public void CameraFLlowPlayer(GameObject target)
    {
        _playerFollowCamera.GetComponent<CinemachineVirtualCamera>().Follow = target.transform;
    }
    public void VrCamShootFLlowPlayer(GameObject target)
    {
        _vrCamShoot.GetComponent<CinemachineVirtualCamera>().Follow = target.transform;
    }
}

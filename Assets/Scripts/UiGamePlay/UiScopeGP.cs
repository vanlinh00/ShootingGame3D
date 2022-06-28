using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScopeGP : MonoBehaviour
{
    public static UiScopeGP instance;
    [SerializeField] GameObject _uiGun;
    [SerializeField] GameObject _uiSniperCult;

    void Start()
    {
        instance = this;
    }

    void Update()
    {

    }
    public void UiGunSetActive()
    {
        CameraController.instance.PlayerSniperCult(false);
        _uiGun.SetActive(true);
        _uiSniperCult.SetActive(false);

    }
    public void UiSniperCultSetActive()
    {
        CameraController.instance.PlayerSniperCult(true);
        _uiGun.SetActive(false);
        _uiSniperCult.SetActive(true);

    }
    public void setAniGunShooting(bool a)
    {
        _uiSniperCult.GetComponent<Animator>().SetBool("isShooting", a);

        _uiGun.GetComponent<Animator>().SetBool("isShooting", a);
    }

}

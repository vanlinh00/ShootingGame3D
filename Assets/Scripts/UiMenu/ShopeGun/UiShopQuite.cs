using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShopQuite : MonoBehaviour
{
    public static UiShopQuite instance;

    [SerializeField] Button btBackGround;
    [SerializeField] Button btQuite;
    private void Awake()
    {
        instance = this;
        btBackGround.onClick.AddListener(DisableShopUi);
        btQuite.onClick.AddListener(DisableShopUi);
    }
    void DisableShopUi()
    {
        CavasControllerMenu.Instance.SetActivePlayer(true);
        CavasControllerMenu.Instance.SetActiveShopUi(false);
        UiShopeSelectGun.instance.setActiveGunDisplay(false);
    }

}

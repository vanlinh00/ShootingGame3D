using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuiteUiShop : MonoBehaviour
{
    public static QuiteUiShop instance;

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
        CavasControllerUiMenu.Instance.SetActivePlayer(true);
        CavasControllerUiMenu.Instance.SetActiveShopUi(false);
        RightTopRightUiShop.instance.SetActiveGunCurrent(false);
        MainUiMenu.instance.SetAnimator("InMain");
    }

}

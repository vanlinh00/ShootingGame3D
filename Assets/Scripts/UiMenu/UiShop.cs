using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShop : MonoBehaviour
{
    public static UiShop instance;

    [SerializeField] Button btBackGround;
    private void Awake()
    {
        instance = this;

        btBackGround.onClick.AddListener(DisableShopUi);
    }
    void Start()
    {

    }

    void Update()
    {

    }

    void DisableShopUi()
    {
        CavasControllerMenu.Instance.SetActivePlayer(true);
        CavasControllerMenu.Instance.SetActiveShopUi(false);
    }

}

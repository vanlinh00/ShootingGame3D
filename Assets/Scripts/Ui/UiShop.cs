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
        btBackGround.onClick.AddListener(DisableShopUi);
    }
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenShop()
    {
        AudioController.instance.OnGame();
        CavasUiController.Instance.SetActivePlayer(false);
        CavasUiController.Instance.SetActiveShopUi(true);
    }
    void DisableShopUi()
    {
        AudioController.instance.MainMenuGame();
        CavasUiController.Instance.SetActivePlayer(true);
        CavasUiController.Instance.SetActiveShopUi(false);
    }

}

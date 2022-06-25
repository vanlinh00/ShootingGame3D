using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUiMenu : MonoBehaviour
{
    [SerializeField] Button _btMiddleLeft;
    [SerializeField] Button _btMiddleRight;
    [SerializeField] Button _btShop;
    private void Awake()
    {
        _btMiddleLeft.onClick.AddListener(NextAnimationl);
        _btMiddleRight.onClick.AddListener(NextAnimationr);
        _btShop.onClick.AddListener(OpenShop);
    }
    void Start()
    {

    }
    void Update()
    {

    }
    void OpenShop()
    {
        AudioController.instance.OnGame();
        CavasControllerMenu.Instance.SetActivePlayer(false);
        CavasControllerMenu.Instance.SetActiveShopUi(true);
    }
    void NextAnimationl()
    {
        AudioController.instance.ButtonClick();
        ChangeAniPlayer.instance.ChangeAnimaiton(true);

        if (ChangeAniPlayer.instance.checkNextAnim == 0)
        {
            _btMiddleLeft.gameObject.SetActive(false);
        }
    }
    void NextAnimationr()
    {
        AudioController.instance.ButtonClick();
        ChangeAniPlayer.instance.ChangeAnimaiton(false);

        if (ChangeAniPlayer.instance.checkNextAnim != 0)
        {
            _btMiddleLeft.gameObject.SetActive(true);
        }

    }
}

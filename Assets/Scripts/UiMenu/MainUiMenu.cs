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

    void OpenShop()
    {
        SoundManager.instance.OnPlayAudio(SoundType.ButtonBlip);
        CavasControllerUiMenu.Instance.SetActivePlayer(false);
        CavasControllerUiMenu.Instance.SetActiveShopUi(true);
    }
    void NextAnimationl()
    {
        SoundManager.instance.OnPlayAudio(SoundType.ButtonBlip);
        ChangeAniPlayerUiMenu.instance.ChangeAnimaiton(true);

        if (ChangeAniPlayerUiMenu.instance.checkNextAnim == 0)
        {
            _btMiddleLeft.gameObject.SetActive(false);
        }
    }
    void NextAnimationr()
    {
        SoundManager.instance.OnPlayAudio(SoundType.ButtonBlip);
        ChangeAniPlayerUiMenu.instance.ChangeAnimaiton(false);

        if (ChangeAniPlayerUiMenu.instance.checkNextAnim != 0)
        {
            _btMiddleLeft.gameObject.SetActive(true);
        }

    }
}

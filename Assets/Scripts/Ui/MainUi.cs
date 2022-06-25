using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUi : MonoBehaviour
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
        UiShop.instance.OpenShop();

    }
    void NextAnimationl()
    {
        AudioController.instance.ButtonClick();
        UiPlayerController.instance.ChangeAnimaiton(true);

        if (UiPlayerController.instance.checkNextAnim == 0)
        {
            _btMiddleLeft.gameObject.SetActive(false);
        }
    }
    void NextAnimationr()
    {
        AudioController.instance.ButtonClick();
        UiPlayerController.instance.ChangeAnimaiton(false);

        if (UiPlayerController.instance.checkNextAnim != 0)
        {
            _btMiddleLeft.gameObject.SetActive(true);
        }

    }
}

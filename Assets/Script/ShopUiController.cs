using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopUiController : MonoBehaviour
{
    [SerializeField] GameObject _mainUi;
    [SerializeField] GameObject _shopUi;

    [SerializeField] Button _middleLeft;
    [SerializeField] Button _middleRight;
    [SerializeField] Button _playGame;
    int checkNextAnim = 0;
    private void Awake()
    {
        _playGame.onClick.AddListener(OnPlayGame);
        _middleLeft.onClick.AddListener(NextAnimationl);
        _middleRight.onClick.AddListener(NextAnimationr);
    }
    void Start()
    {
        _middleLeft.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkNextAnim != 0)
        {
            _middleLeft.gameObject.SetActive(true);
        }
        else
        {
            _middleLeft.gameObject.SetActive(false);

        }
    }
    void OnPlayGame()
    {
        SceneManager.LoadScene(1);
    }
    void NextAnimationl()
    {
        if (checkNextAnim != 0)
        {
            checkNextAnim--;
        }
        UiPlayerController.instance.AnimatorPlayer(checkNextAnim);
    }
    void NextAnimationr()
    {
        checkNextAnim++;
        if (checkNextAnim == 3)
        {
            checkNextAnim = 0;
        }
        UiPlayerController.instance.AnimatorPlayer(checkNextAnim);
    }


}

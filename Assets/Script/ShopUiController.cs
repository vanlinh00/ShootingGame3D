using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopUiController : MonoBehaviour
{
    [SerializeField] GameObject _mainUi;
    [SerializeField] GameObject _shopUi;
    [SerializeField] GameObject _player;

    [SerializeField] Button _middleLeft;
    [SerializeField] Button _middleRight;
    [SerializeField] Button _playGame;
    [SerializeField] Button _btShop;

    [SerializeField] Image _imBackGround;

    int checkNextAnim = 0;
    private void Awake()
    {

        // tim hieu cach lam so de lam ngon hon cho onclick nay trong unity 3d vietnam co hoc di
        _playGame.onClick.AddListener(OnPlayGame);
        _middleLeft.onClick.AddListener(NextAnimationl);
        _middleRight.onClick.AddListener(NextAnimationr);
        _btShop.onClick.AddListener(OpenShop);
    }
    void Start()
    {
        AudioController.instance.MainMenuGame();
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
        if (_imBackGround.gameObject.GetComponent<EventUi>().isOnPointerClick)
        {
            AudioController.instance.MainMenuGame();
            _player.SetActive(true);
            _shopUi.SetActive(false);
            _imBackGround.gameObject.GetComponent<EventUi>().isOnPointerClick = false;
        }
    }
    void OnPlayGame()
    {
        AudioController.instance.ButtonClick();
        SceneManager.LoadScene(1);
    }
    void NextAnimationl()
    {
        AudioController.instance.ButtonClick();
        if (checkNextAnim != 0)
        {
            checkNextAnim--;
        }
        UiPlayerController.instance.AnimatorPlayer(checkNextAnim);
    }
    void NextAnimationr()
    {
        AudioController.instance.ButtonClick();
        checkNextAnim++;
        if (checkNextAnim == 3)
        {
            checkNextAnim = 0;
        }
        UiPlayerController.instance.AnimatorPlayer(checkNextAnim);
    }
    void OpenShop()
    {

        AudioController.instance.OnGame();
        _player.SetActive(false);
        _shopUi.SetActive(true);
    }

}

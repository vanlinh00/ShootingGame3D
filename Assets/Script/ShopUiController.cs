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
    // 0     1         2
    //   0    -1        -2
    private string[] _textAnimation = { "run", "idle", "shoot" };
    int check = 0;
    private void Awake()
    {
        _playGame.onClick.AddListener(OnPlayGame);
        _middleLeft.onClick.AddListener(NextAnimationl);
        _middleRight.onClick.AddListener(NextAnimationr);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnPlayGame()
    {
        SceneManager.LoadScene(1);
    }
    void NextAnimationl()
    {
        if (check != 0)
        {
            check--;
            Debug.Log(_textAnimation[check]);

        }

    }
    void NextAnimationr()
    {
        if (check != _textAnimation.Length)
        {
            check++;
            Debug.Log(_textAnimation[check]);
        }
        else
        {
            check = 0;
            Debug.Log(_textAnimation[check]);

        }

    }

}

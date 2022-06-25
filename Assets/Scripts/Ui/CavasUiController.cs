using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// tim hieu cach lam so de lam ngon hon cho onclick nay trong unity 3d vietnam co hoc di
// cai nay can update cho de the nay qua khong on

/*
 * lam them chuc nang mua sung va save sung
 */
public class CavasUiController : MonoBehaviour
{
    public static CavasUiController Instance;
    [SerializeField] GameObject _mainUi;
    [SerializeField] GameObject _shopUi;

    [SerializeField] GameObject _player;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SetActiveShopUi(false);
        AudioController.instance.MainMenuGame();
    }
    void Update()
    {

    }
    public void SetActivePlayer(bool res)
    {
        _player.SetActive(res);
    }
    public void SetActiveShopUi(bool res)
    {
        _shopUi.SetActive(res);
    }


}

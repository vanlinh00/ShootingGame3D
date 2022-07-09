using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CavasControllerUiMenu : MonoBehaviour
{
    public static CavasControllerUiMenu Instance;
    [SerializeField] GameObject _mainUi;
    [SerializeField] GameObject _shopUi;

    [SerializeField] GameObject _player;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // MusicManager.instance.OnPlayMusic(MusicType.MainMenu);
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

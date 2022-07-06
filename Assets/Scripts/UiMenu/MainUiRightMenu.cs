using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainUiRightMenu : MonoBehaviour
{
    [SerializeField] Button _btPlayGame;
    private void Awake()
    {
        _btPlayGame.onClick.AddListener(OnPlayGame);
    }
    void Start()
    {

    }

    void Update()
    {

    }
    void OnPlayGame()
    {
        MusicManager.instance.OnPlayMusic(MusicType.CountDown);
        SceneManager.LoadScene(1);
    }

}

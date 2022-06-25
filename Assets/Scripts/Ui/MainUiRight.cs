using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainUiRight : MonoBehaviour
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
        AudioController.instance.ButtonClick();
        SceneManager.LoadScene(1);
    }

}

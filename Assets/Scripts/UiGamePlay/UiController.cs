using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UiController : Singleton<UiController>
{

    [SerializeField] GameObject _cavaAndGame;

    [SerializeField] GameObject _uiPickUp;

    public NetworkIdentity networkIdentity;  // for game online

    void Start()
    {
        _cavaAndGame.SetActive(false);

    }


    public void EndGame(string result)
    {
        _cavaAndGame.SetActive(true);
        UiEndGameGP.instance.EndGame(result);
    }
    public void SetVisibleUiPickUp(bool result)
    {
        _uiPickUp.SetActive(result);
    }
    void Update()
    {
        // cai nay de test dung xong xoa di
        if (Input.GetKey("k"))
        {
            // networkIdentity.GetSocket().Emit("disconnect", "hi");  // for gameOnline
            Screen.lockCursor = false;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiEndGameGP : MonoBehaviour
{
    public static UiEndGameGP instance;
    [SerializeField] Text _textEndGame;
    [SerializeField] Button _btEndgame;
    private void Awake()
    {

        instance = this;
        _btEndgame.onClick.AddListener(RestartGame);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame(string res)
    {
        Screen.lockCursor = false;
        Cursor.visible = true;
        _textEndGame.text = res;
    }

    public void RestartGame()
    {
        // networkIdentity.GetSocket().Emit("disconnect", "hi");  // for game online
        SceneManager.LoadScene(0);
    }
}

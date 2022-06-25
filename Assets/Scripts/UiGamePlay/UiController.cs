using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//player co thanh tren ui
// hien thi so nguoi con tren  mapp khi het nguoi chien thang
// lam ui dang nhap vao
// lam ui cho thanh mau cho player || hien thi nguoi trong mapp | hiên thi ten nguoi loi trong game  online
// lam chat giua 1 nguoi choi
// lam tu do
// lam animation muot hon
// hien thi thang cuoc

// lam ui  cho man hinh load game player

public class UiController : MonoBehaviour
{
    // code chua clean can duoc clean lai
    public static UiController instance;

    [SerializeField] GameObject _uiGun;
    [SerializeField] GameObject _uiSniperCult;
    [SerializeField] GameObject _cavaAndGame;

    [SerializeField]
    public Image _healthBar;


    [SerializeField] Text _countEnemy;
    [SerializeField] Text _textEndGame;

    [SerializeField] Button _btEndgame;

    [SerializeField] GameObject _Player;   // player nay khong lien quan de Ui sao cho vao day


    public NetworkIdentity networkIdentity;

    private void Awake()
    {
        _btEndgame.onClick.AddListener(RestartGame);
    }
    void Start()
    {
        _cavaAndGame.SetActive(false);
        _countEnemy.text = "19/19";
    }
    public void setCavaEndGame(bool result)
    {
        Screen.lockCursor = false;
        Cursor.visible = true;
        _cavaAndGame.SetActive(result);
    }
    public void RestartGame()
    {
        // networkIdentity.GetSocket().Emit("disconnect", "hi");  // for game online
        SceneManager.LoadScene(0);
    }
    public void EndGame(string res)
    {
        _textEndGame.text = res;
    }
    public void countEnemy()
    {
        _countEnemy.text = GameController.instance._listEnemy.Count + "/19";
        if (GameController.instance._isCreateAllEnemy == true)
        {
            if (GameController.instance._listEnemy.Count <= 0)
            {
                setCavaEndGame(true);
                EndGame("YOU WIN");
            }
        }

    }

    void Update()
    {

        instance = this;
        countEnemy();

        // cai nay de test dung xong xoa di
        if (Input.GetKey("k"))
        {
            // networkIdentity.GetSocket().Emit("disconnect", "hi");  // for gameOnline
            Screen.lockCursor = false;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }

    }
    public void UiGun(bool a)
    {
        _uiGun.SetActive(a);
    }
    public void UiSniperCult(bool a)
    {
        _uiSniperCult.SetActive(a);
    }


}

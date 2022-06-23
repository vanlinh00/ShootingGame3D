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

// hien thi man hinh dem  5 s khi start game
public class UiController : MonoBehaviour
{
    public static UiController instance;

    [SerializeField] GameObject _uiGun;
    [SerializeField] GameObject _uiSniperCult;
    [SerializeField] GameObject _cavaAndGame;

    [SerializeField]
    public Image _healthBar;

    [SerializeField] Text _countText;
    [SerializeField] Text _countEnemy;
    [SerializeField] Text _textEndGame;

    [SerializeField] Button _btEndgame;

    float coutTime = 4f;
    [SerializeField]
    GameObject myPlayer;


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
        networkIdentity.GetSocket().Emit("disconnect", "hi");
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
        if (coutTime >= -1f)
        {
            CountTimeStartGame();
        }
        instance = this;
        countEnemy();

        // cai nay de test dung xong xoa di
        if (Input.GetKey("k"))
        {
            networkIdentity.GetSocket().Emit("disconnect", "hi");
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
    public void CountTimeStartGame()
    {
        coutTime -= Time.deltaTime;
        if (coutTime > 3f && coutTime <= 3.1f)
        {
            _countText.text = "3";
        }
        if (coutTime > 2f && coutTime <= 2.1f)
        {
            _countText.text = "2";
        }
        if (coutTime > 1f && coutTime <= 1.1f)
        {
            _countText.text = "1";
        }
        if (coutTime > 0f && coutTime <= 0.1f)
        {
            _countText.text = "0";

        }
        if (coutTime > -1f && coutTime <= -0.9f)
        {
            _countText.gameObject.SetActive(false);
        }
    }

}

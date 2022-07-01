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
    public static UiController instance;

    [SerializeField] GameObject _cavaAndGame;
    [SerializeField] GameObject _Player;   // player nay khong lien quan de Ui sao cho vao day


    public NetworkIdentity networkIdentity;  // for game online

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        _cavaAndGame.SetActive(false);

    }


    public void EndGame(string result)
    {
        _cavaAndGame.SetActive(true);
        UiEndGameGP.instance.EndGame(result);
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

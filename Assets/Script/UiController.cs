using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] GameObject _uiGun;
    [SerializeField] GameObject _uiSniperCult;


    private void Awake()
    {

    }
    void Start()
    {
        instance = this;

    }
    void Update()
    {

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

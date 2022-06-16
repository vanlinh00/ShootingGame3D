using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//player co thanh tren ui
// hien thi so nguoi con tren  mapp khi het nguoi chien thang


// lam ui dang nhap vao
public class UiController : MonoBehaviour
{
    public static UiController instance;
    [SerializeField] GameObject _uiGun;
    [SerializeField] GameObject _uiSniperCult;
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

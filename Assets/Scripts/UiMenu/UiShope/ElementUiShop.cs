using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUiShop : MonoBehaviour
{
    public int id;
    public Image _backGround;
    public Gun _gun;
    public Text _textnameGun;
    public Button _btSelectGun;
    public GameObject _darkBackGround;
    public GameObject _lock;
    private void Awake()
    {
        _btSelectGun.onClick.AddListener(SelectGun);
    }
    private void OnValidate()
    {
        _backGround = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        _gun = GetComponentInChildren<Gun>();
        _btSelectGun = GetComponent<Button>();
        _textnameGun = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        _darkBackGround = this.gameObject.transform.GetChild(3).gameObject;
        _lock = this.gameObject.transform.GetChild(5).gameObject;

    }
    public void SelectGun()
    {
        // _backGround.color = new Color32(255, 25, 43, 225);
        RightTopRightUiShop.instance.ChangePropertiesGun(_gun.damage, _gun.rateOfFire, _gun.accuracy, _gun.name, _gun.id);
    }
}


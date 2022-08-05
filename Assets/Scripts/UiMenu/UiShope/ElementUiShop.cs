using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUiShop : MonoBehaviour
{
    public int id;
    public Image _backGround;
    public Weapon _weapon;
    public Image _weaponImage;
    public Text _textnameWeapon;
    public Button _btSelectWeapon;
    public GameObject _darkBackGround;
    public GameObject _lock;

    private void Awake()
    {
        _btSelectWeapon.onClick.AddListener(SelectWeapon);

    }
    private void OnValidate()
    {
        _backGround = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        _weapon = GetComponentInChildren<Weapon>();

        _weaponImage = this.gameObject.transform.GetChild(2).GetComponent<Image>();
        _btSelectWeapon = GetComponent<Button>();

        _textnameWeapon = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        _darkBackGround = this.gameObject.transform.GetChild(3).gameObject;

        _lock = this.gameObject.transform.GetChild(5).gameObject;

    }
    public void IsLock()
    {
        _darkBackGround.SetActive(true);
        _lock.SetActive(true);
    }
    public void IsButtonGun(int idImage)
    {
        _weaponImage.sprite = Resources.Load<Sprite>("ShopeGun/Weapon/Image/Gun/" + idImage);
    }
    public void IsButtonKnive(int idImage)
    {
        _weaponImage.sprite = Resources.Load<Sprite>("ShopeGun/Weapon/Image/Knives/" + idImage);
    }
    public void IsButtonKPan()
    {
        // _weaponImage. load pans image
    }
    public void SelectWeapon()
    {

        // _backGround.color = new Color32(255, 25, 43, 225);
        LoadWeaponUiShop.instance.ChangePropertiesGun(_weapon.damage, _weapon.rateOfFire, _weapon.accuracy, _weapon.name, _weapon.id, _weapon.priceForCoin, _weapon.priceForDiamond);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadWeaponUiShop : Singleton<LoadWeaponUiShop>
{
    [SerializeField] Image _barDamageWeapon;
    [SerializeField] Image _barRateOfFireWeapon;
    [SerializeField] Image _barAccuracyWeapon;
    [SerializeField] Text _nameWeapon;

    GameObject _gunCurrent;

    Vector3 _positionGun = Vector3.zero;
    protected override void Awake()
    {
        base.Awake();
        //  CreateGun(0);
    }
    public void ChangePropertiesGun(float newDamage, float newRateOfFire, float newAccuracy, string nameGun, int idWeapon)
    {
        _barDamageWeapon.fillAmount = newDamage;
        _barRateOfFireWeapon.fillAmount = newRateOfFire;
        _barAccuracyWeapon.fillAmount = newAccuracy;
        _nameWeapon.text = nameGun;
        CreateGun(idWeapon);
    }
    public void CreateGun1(int idWeapon)
    {
        Debug.Log("tai sao");
    }
    public void CreateGun(int idWeapon)
    {
        if (_gunCurrent != null)
        {
            Destroy(_gunCurrent);
        }

        if (SelectGunUiShop.instance.getIdWeaPonDisplay() == 1)
        {
            string nameGunInAsset = "Gun_" + idWeapon;
            GameObject _newWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/Gun/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
            _gunCurrent = _newWeapon;
        }

        if (SelectGunUiShop.instance.getIdWeaPonDisplay() == 2)
        {
            string nameGunInAsset = "Knife_" + idWeapon;
            GameObject _newWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/Knives/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
            _gunCurrent = _newWeapon;
        }

    }
    public void SetActiveGunCurrent(bool result)
    {
        _gunCurrent.SetActive(result);
    }
}

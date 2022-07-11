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

    private GameObject _weaPonCurrent;

    Vector3 _positionGun = Vector3.zero;
    protected override void Awake()
    {
        base.Awake();
    }
    public void ChangePropertiesGun(float newDamage, float newRateOfFire, float newAccuracy, string nameGun, int idWeapon)
    {
        _barDamageWeapon.fillAmount = newDamage;
        _barRateOfFireWeapon.fillAmount = newRateOfFire;
        _barAccuracyWeapon.fillAmount = newAccuracy;
        _nameWeapon.text = nameGun;
        CreateWeapon(idWeapon);
    }
    public void CreateWeapon(int idWeapon)
    {
        if (_weaPonCurrent != null)
        {
            Destroy(_weaPonCurrent);
        }

        if (SelectWeaponUiShop.instance.getIdWeaPonDisplay() == 1)
        {
            string nameGunInAsset = "Gun_" + idWeapon;
            GameObject _newWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/Gun/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
            _weaPonCurrent = _newWeapon;
        }

        if (SelectWeaponUiShop.instance.getIdWeaPonDisplay() == 2)
        {
            string nameGunInAsset = "Knife_" + idWeapon;
            GameObject _newWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/Knives/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
            _weaPonCurrent = _newWeapon;
        }

    }
    public void SetActiveGunCurrent(bool result)
    {
        _weaPonCurrent.SetActive(result);
    }
}

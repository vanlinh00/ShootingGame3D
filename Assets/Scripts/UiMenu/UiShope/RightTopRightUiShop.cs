using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RightTopRightUiShop : Singleton<RightTopRightUiShop>
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
        CreateGun(2);
    }
    public void ChangePropertiesGun(float newDamage, float newRateOfFire, float newAccuracy, string nameGun, int idGun)
    {
        _barDamageWeapon.fillAmount = newDamage;
        _barRateOfFireWeapon.fillAmount = newRateOfFire;
        _barAccuracyWeapon.fillAmount = newAccuracy;
        _nameWeapon.text = nameGun;
        CreateGun(idGun);
    }
    public void CreateGun(int idGun)
    {
        if (_gunCurrent != null)
        {
            Destroy(_gunCurrent);
        }
        string nameGunInAsset = "Gun_" + idGun;
        GameObject _newGun = Instantiate(Resources.Load("ShopeGun/Weapon/Gun/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
        _gunCurrent = _newGun;
    }
    public void SetActiveGunCurrent(bool result)
    {
        _gunCurrent.SetActive(result);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RightTopRightUiShop : Singleton<RightTopRightUiShop>
{
    [SerializeField] Image _barDamageGun;
    [SerializeField] Image _barRateOfFireGun;
    [SerializeField] Image _barAccuracyGun;
    [SerializeField] Text _nameGun;

    GameObject _gunCurrent;

    Vector3 _positionGun = Vector3.zero;
    protected override void Awake()
    {
        base.Awake();
        CreateGun(0);
    }
    public void ChangePropertiesGun(float newDamage, float newRateOfFire, float newAccuracy, string nameGun, int idGun)
    {
        _barDamageGun.fillAmount = newDamage;
        _barRateOfFireGun.fillAmount = newRateOfFire;
        _barAccuracyGun.fillAmount = newAccuracy;
        _nameGun.text = nameGun;
        CreateGun(idGun);
    }
    void CreateGun(int idGun)
    {
        if (_gunCurrent != null)
        {
            Destroy(_gunCurrent);
        }
        string nameGunInAsset = "Gun_" + idGun;
        GameObject _newGun = Instantiate(Resources.Load("ShopeGun/" + nameGunInAsset, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
        _gunCurrent = _newGun;
    }
    public void SetActiveGunCurrent(bool result)
    {
        _gunCurrent.SetActive(result);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiShopeRightTopRight : Singleton<UiShopeRightTopRight>
{
    [SerializeField] Image _barDamage;
    [SerializeField] Image _barRateOfFire;
    [SerializeField] Image _barAccuracy;
    protected override void Awake()
    {
        base.Awake();
    }
    public void ChangePropertiesGun(float newDamage, float newRateOfFire, float newAccuracy)
    {
        _barDamage.fillAmount = newDamage;
        _barRateOfFire.fillAmount = newRateOfFire;
        _barAccuracy.fillAmount = newAccuracy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectEquipmentUiShop : MonoBehaviour
{
    [SerializeField] Button _primaryButton;
    [SerializeField] Button _knivesButton;
    [SerializeField] Button _pansButton;
    private void Awake()
    {
        _primaryButton.onClick.AddListener(OpenShopGun);
        _knivesButton.onClick.AddListener(OpenShopKnives);
        _pansButton.onClick.AddListener(OpenpansButton);
        // _pans.onClick.AddListener()
    }

    void OpenpansButton()
    {
        SelectWeaponUiShop.instance.testc();
    }
    void OpenShopGun()
    {
        SelectWeaponUiShop.instance.OpenStoreWeapon(1);
    }
    void OpenShopKnives()
    {
        SelectWeaponUiShop.instance.OpenStoreWeapon(2);
    }

    void Update()
    {

    }
}

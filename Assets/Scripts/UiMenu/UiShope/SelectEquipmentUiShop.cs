using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectEquipmentUiShop : MonoBehaviour
{
    [SerializeField] Button _primaryButton;
    [SerializeField] Button _knivesButton;
    private void Awake()
    {
        _primaryButton.onClick.AddListener(OpenShopGun);
        _knivesButton.onClick.AddListener(OpenShopKnives);
    }

    void Start()
    {

    }
    void OpenShopGun()
    {
        SelectGunUiShop.instance.OpenStoreWeapon(1);
    }
    void OpenShopKnives()
    {
        SelectGunUiShop.instance.OpenStoreWeapon(2);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

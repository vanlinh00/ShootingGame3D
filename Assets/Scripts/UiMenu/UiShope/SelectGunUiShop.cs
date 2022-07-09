using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGunUiShop : MonoBehaviour
{
    public ElementUiShop[] _listElementUiShopS;
    void Start()
    {

    }
    private void Awake()
    {
        SetData();
    }
    public void SetData()
    {
        for (int i = 0; i < _listElementUiShopS.Length; i++)
        {
            _listElementUiShopS[i].id = i;
            _listElementUiShopS[i]._gun.id = i;
            _listElementUiShopS[i]._gun.name = "gun" + i;
            _listElementUiShopS[i]._gun.damage = 0.5f;
            _listElementUiShopS[i]._gun.rateOfFire = 0.5f;
            _listElementUiShopS[i]._gun.accuracy = 0.5f;

        }
    }
    private void OnValidate()
    {
        if (_listElementUiShopS == null || _listElementUiShopS.Length == 0)
        {
            _listElementUiShopS = GetComponentsInChildren<ElementUiShop>();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}

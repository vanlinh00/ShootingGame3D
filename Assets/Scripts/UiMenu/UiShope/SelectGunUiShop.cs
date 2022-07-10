using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGunUiShop : MonoBehaviour
{
    // public ElementUiShop[] _listElementUiShopS;
    public List<ElementUiShop> _listElementUiShops;
    void Start()
    {

    }
    private void Awake()
    {
        // SetData();
    }


    // 1 create list guns
    // 2 create list knives
    // 3 create list pans
    public void SetData(int choose, int allWeapon, int allWeaponUnlock)
    {
        switch (choose)
        {
            case 0:
                // do something
                break;
            case 1:
                // do something
                break;
            case 2:
                break;

        };

        for (int i = 0; i < allWeapon; i++)
        {
            //_listElementUiShopS[i].id = i;
            //_listElementUiShopS[i]._weapon.id = i;
            //_listElementUiShopS[i]._weapon.name = "gun" + i;
            //_listElementUiShopS[i]._weapon.damage = 0.5f;
            //_listElementUiShopS[i]._weapon.rateOfFire = 0.5f;
            //_listElementUiShopS[i]._weapon.accuracy = 0.5f;

        }
    }

    //public void SetData()
    //{
    //    for (int i = 0; i < _listElementUiShopS.Length; i++)
    //    {
    //        _listElementUiShopS[i].id = i;
    //        _listElementUiShopS[i]._weapon.id = i;
    //        _listElementUiShopS[i]._weapon.name = "gun" + i;
    //        _listElementUiShopS[i]._weapon.damage = 0.5f;
    //        _listElementUiShopS[i]._weapon.rateOfFire = 0.5f;
    //        _listElementUiShopS[i]._weapon.accuracy = 0.5f;

    //    }
    //}

    //private void OnValidate()
    //{
    //    if (_listElementUiShopS == null || _listElementUiShopS.Length == 0)
    //    {
    //        _listElementUiShopS = GetComponentsInChildren<ElementUiShop>();
    //    }
    //}

}

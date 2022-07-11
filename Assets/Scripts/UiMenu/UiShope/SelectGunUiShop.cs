using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGunUiShop : Singleton<SelectGunUiShop>
{
    // public ElementUiShop[] _listElementUiShopS;
    public List<ElementUiShop> _listElementUiShops;
    [SerializeField] GameObject _content;
    private int idWeaPonDisplay = 1;
    void Start()
    {

    }
    protected override void Awake()
    {
        base.Awake();
        OpenStoreWeapon(1);
    }
    public int getIdWeaPonDisplay()
    {
        return idWeaPonDisplay;
    }
    public void OpenStoreWeapon(int idWeaPon)
    {
        idWeaPonDisplay = idWeaPon;
        SetData(idWeaPonDisplay, 10, 2);

    }

    // 1 create list guns
    // 2 create list knives
    // 3 create list pans
    public void SetData(int choose, int allWeapon, int allWeaponUnlock)
    {
        // Destroy All Children of Object
        foreach (Transform child in _content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < allWeapon; i++)
        {
            CreateListGuns(i, allWeaponUnlock, choose);
        }

        //LoadWeaponUiShop.instance.CreateGun1(0);
    }
    void CreateListGuns(int i, int allWeaponUnlock, int choose)
    {
        GameObject newButtonWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/shop_button_element", typeof(GameObject)), _content.transform.position, Quaternion.identity) as GameObject;
        newButtonWeapon.transform.parent = _content.transform;
        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.id = i;

        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.damage = 0.5f;
        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.rateOfFire = 0.5f;
        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.accuracy = 0.5f;

        switch (choose)
        {
            case 1:
                newButtonWeapon.GetComponent<ElementUiShop>()._weapon.name = "gun" + i;
                newButtonWeapon.GetComponent<ElementUiShop>().IsButtonGun(i);
                break;
            case 2:
                newButtonWeapon.GetComponent<ElementUiShop>()._weapon.name = "knive" + i;
                newButtonWeapon.GetComponent<ElementUiShop>().IsButtonKnive(i);
                break;
            case 3:
                newButtonWeapon.GetComponent<ElementUiShop>()._weapon.name = "pan" + i;
                newButtonWeapon.GetComponent<ElementUiShop>().IsButtonKPan();
                break;
        };

        if (i > allWeaponUnlock)
        {
            newButtonWeapon.GetComponent<ElementUiShop>().IsLock();
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

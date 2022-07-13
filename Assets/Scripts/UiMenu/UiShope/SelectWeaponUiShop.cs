using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeaponUiShop : Singleton<SelectWeaponUiShop>
{
    // public ElementUiShop[] _listElementUiShopS;
    public List<ElementUiShop> _listElementUiShops;

    [SerializeField] GameObject _content;

    private int idWeaPonDisplay = 1;
    private int allWeapon = 10;
    private int allWeaponUnlock = 2;

    protected override void Awake()
    {
        base.Awake();
        OpenStoreWeapon(1);
    }
    public int getIdWeaPonDisplay()
    {
        return idWeaPonDisplay;
    }
    public void OpenStoreWeapon(int idChooseWeaPon)
    {

        StartCoroutine(OpenStoreWeaponCoroutine(idChooseWeaPon));
    }

    IEnumerator OpenStoreWeaponCoroutine(int idChooseWeaPon)
    {
        idWeaPonDisplay = idChooseWeaPon;
        SetData(idWeaPonDisplay, allWeapon, allWeaponUnlock);
        LoadWeaponUiShop.instance.CreateWeapon(0);

        yield return new WaitForSeconds(0.1f);

        _content.transform.GetChild(0).GetComponent<ElementUiShop>().SelectWeapon();
    }

    // chosse = 1 create list guns
    // chosse = 2 create list knives
    // chosse = 3 create list pans
    public void SetData(int choose, int allWeapon, int allWeaponUnlock)
    {
        foreach (Transform child in _content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < allWeapon; i++)
        {
            CreateListGuns(i, allWeaponUnlock, choose);
        }
    }
    void CreateListGuns(int i, int allWeaponUnlock, int choose)
    {
        GameObject newButtonWeapon = Instantiate(Resources.Load("ShopeGun/Weapon/shop_button_element", typeof(GameObject)), _content.transform.position, Quaternion.identity) as GameObject;
        newButtonWeapon.transform.parent = _content.transform;

        float randomDamge = Random.RandomRange(0.2f, 1f);
        float randomrateOfFire = Random.RandomRange(0.2f, 1f);
        float randomaccuracy = Random.RandomRange(0.2f, 1f);

        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.id = i;
        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.damage = randomDamge;
        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.rateOfFire = randomrateOfFire;
        newButtonWeapon.GetComponent<ElementUiShop>()._weapon.accuracy = randomaccuracy;

        switch (choose)
        {
            case 1:
                newButtonWeapon.GetComponent<ElementUiShop>()._weapon.name = "gun" + i;
                newButtonWeapon.GetComponent<ElementUiShop>().IsButtonGun(i);
                newButtonWeapon.GetComponent<ElementUiShop>()._textnameWeapon.text = "Gun" + i;
                break;
            case 2:
                newButtonWeapon.GetComponent<ElementUiShop>()._weapon.name = "knive" + i;
                newButtonWeapon.GetComponent<ElementUiShop>().IsButtonKnive(i);
                newButtonWeapon.GetComponent<ElementUiShop>()._textnameWeapon.text = "Knife" + i;
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

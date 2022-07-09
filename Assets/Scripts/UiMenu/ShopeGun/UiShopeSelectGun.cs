using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShopeSelectGun : Singleton<UiShopeSelectGun>
{
    [SerializeField] List<Button> _listButtonGun;
    [SerializeField] GameObject _buttonGunOpen;
    [SerializeField] GameObject _buttonGunClose;

    [SerializeField] Vector3 _positionGun = Vector3.zero;

    private int countGunOfPlayer;
    private int countALLGunOfGame;
    private GameObject _gunLoadCurrent;
    protected override void Awake()
    {
        base.Awake();
        countGunOfPlayer = 2;
        countALLGunOfGame = 10;
        OnLoadDataGunButton(countALLGunOfGame, countGunOfPlayer);
        for (int i = 0; i < _listButtonGun.Count; i++)
        {
            int temp = i;
            _listButtonGun[i].onClick.AddListener(() =>
            {
                LoadGun(temp);
            });

        }
    }
    private void Start()
    {
        Gun inforGun = new Gun();
        inforGun.id = 0;
        inforGun.damage = 0.5f;
        inforGun.rateOfFire = 0.5f;
        inforGun.accuracy = 0.5f;

        CreateNewGun(0);
    }
    private void OnLoadDataGunButton(int countAllGun, int countGunOpen)
    {
        for (int i = 0; i < countAllGun; i++)
        {
            GameObject newButtonGun;
            if (i <= countGunOpen)
            {
                newButtonGun = Instantiate(_buttonGunOpen, this.transform.position, Quaternion.identity, this.gameObject.transform);
                newButtonGun.transform.GetChild(0).GetComponent<ButtonGun>().idGun = i;
                _listButtonGun.Add(newButtonGun.transform.GetChild(0).GetComponent<Button>());

            }
            else
            {
                newButtonGun = Instantiate(_buttonGunClose, this.transform.position, Quaternion.identity, this.gameObject.transform);
                newButtonGun.transform.GetChild(4).GetComponent<ButtonGun>().idGun = i;
                _listButtonGun.Add(newButtonGun.transform.GetChild(4).GetComponent<Button>());
            }

        }
    }
    void LoadGun(int idButton)
    {
        if (countGunOfPlayer >= idButton)
        {
            setActiveGunDisplay(false);
            Destroy(_gunLoadCurrent);

            CreateNewGun(idButton);
        }
        else
        {
            Debug.Log("chua du tuoi nhe pro");
        }

    }
    void CreateNewGun(int idButton)
    {

        Gun inforGun = new Gun();
        inforGun.id = idButton;
        inforGun.damage = 0.5f;
        inforGun.rateOfFire = 0.5f;
        inforGun.accuracy = 0f;

        string nameGun = "Gun_" + idButton;
        GameObject _newGun = Instantiate(Resources.Load("ShopeGun/" + nameGun, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
        _newGun.AddComponent<Gun>();
        _newGun.GetComponent<Gun>().id = inforGun.id;
        _newGun.GetComponent<Gun>().damage = inforGun.damage;
        _newGun.GetComponent<Gun>().rateOfFire = inforGun.rateOfFire;
        _newGun.GetComponent<Gun>().accuracy = inforGun.accuracy;

        UiShopeRightTopRight.instance.ChangePropertiesGun(inforGun.damage, inforGun.rateOfFire, inforGun.accuracy);
        _gunLoadCurrent = _newGun;
    }
    public void setActiveGunDisplay(bool res)
    {
        if (_gunLoadCurrent != null)
        {
            _gunLoadCurrent.SetActive(res);
        }
    }
}

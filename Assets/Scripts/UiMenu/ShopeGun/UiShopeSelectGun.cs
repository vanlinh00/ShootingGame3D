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
        OnLoadDataGun(countALLGunOfGame, countGunOfPlayer);
        for (int i = 0; i < _listButtonGun.Count; i++)
        {
            int temp = i;
            _listButtonGun[i].onClick.AddListener(() =>
            {
                loadGun(temp);
            });

        }
    }
    private void Start()
    {
        GameObject _newGun = Instantiate(Resources.Load("ShopeGun/Gun_0", typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
        _gunLoadCurrent = _newGun;
    }
    private void OnLoadDataGun(int countAllGun, int countGunOpen)
    {
        for (int i = 0; i < countAllGun; i++)
        {
            GameObject newButtonGun;
            if (i <= countGunOpen)
            {
                newButtonGun = Instantiate(_buttonGunOpen, this.transform.position, Quaternion.identity, this.gameObject.transform);
            }
            else
            {
                newButtonGun = Instantiate(_buttonGunClose, this.transform.position, Quaternion.identity, this.gameObject.transform);
            }
            newButtonGun.GetComponent<ButtonGun>().idGun = i;

            _listButtonGun.Add(newButtonGun.GetComponent<Button>());
        }
    }
    void loadGun(int idButton)
    {
        setActiveGunDisplay(false);
        Destroy(_gunLoadCurrent);
        string nameGun = "Gun_" + idButton;
        GameObject _newGun = Instantiate(Resources.Load("ShopeGun/" + nameGun, typeof(GameObject)), _positionGun, Quaternion.identity) as GameObject;
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

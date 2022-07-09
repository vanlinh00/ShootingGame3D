using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUiShop : MonoBehaviour
{
    public int id;
    public string name;
    public Button _btSelectGun;
    public GameObject _darkBackGround;
    public GameObject _lock;
    private void Awake()
    {
        _btSelectGun.onClick.AddListener(SelectGun);
    }
    private void OnValidate()
    {
        _btSelectGun = GetComponent<Button>();
    }
    public void SelectGun()
    {
        Debug.Log("Load gun");
    }
}


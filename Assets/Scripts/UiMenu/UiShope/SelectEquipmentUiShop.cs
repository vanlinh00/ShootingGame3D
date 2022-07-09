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
        Debug.Log("OpenShopGun");
    }
    void OpenShopKnives()
    {
        Debug.Log("OpenShopKnives");
    }
    // Update is called once per frame
    void Update()
    {

    }
}

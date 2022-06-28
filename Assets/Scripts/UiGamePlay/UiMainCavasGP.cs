using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMainCavasGP : MonoBehaviour
{
    public static UiMainCavasGP instance;

    [SerializeField] Text _txtCountStartGame;

    [SerializeField] Text _countEnemy;

    float coutTime = 3.2f;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _countEnemy.text = "19/19";
    }
    void Update()
    {
        if (coutTime >= -1f)
        {
            CountTimeStartGame();
        }
        countEnemy();
    }
    public void countEnemy()
    {
        _countEnemy.text = GameController.instance._listEnemy.Count + "/19";
        if (GameController.instance._isCreateAllEnemy == true)
        {
            if (GameController.instance._listEnemy.Count <= 0)
            {
                UiController.instance.EndGame();
            }
        }
    }
    public void CountTimeStartGame()
    {
        coutTime -= Time.deltaTime;
        for (int i = 3; i > -1; i--)
        {
            if (coutTime > i && coutTime <= i + 0.1f)
            {
                _txtCountStartGame.text = "" + i;
            }
        }
        if (coutTime > -1f && coutTime <= -0.9f)
        {
            _txtCountStartGame.gameObject.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMainCavasGP : Singleton<UiMainCavasGP>
{
    [SerializeField] Text _txtCountStartGame;
    [SerializeField] Text _countEnemy;

    int _totalEnemyCurrent = 0;
    int _totalEnemy = 0;

    float coutTime = 3.2f;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        if (EnemyManager.instance._isCreateAllEnemy == true)
        {
            _totalEnemyCurrent = EnemyManager.instance._listEnemy.Count;
            _totalEnemy = _totalEnemyCurrent;
            _countEnemy.text = _totalEnemyCurrent + "/" + _totalEnemy;
        }
    }
    private void OnEnable()
    {
        EventManager.EnemyDeath += EventManagerOnEnemyDeath;
    }
    //private void OnDisable()
    //{
    //    EventManager.EnemyDeath -= EventManagerOnEnemyDeath;
    //}
    private void EventManagerOnEnemyDeath()
    {
        _totalEnemyCurrent--;
        _countEnemy.text = _totalEnemyCurrent + "/" + _totalEnemy;
        if (_totalEnemyCurrent <= 0)
        {
            UiControllerGP.instance.EndGame("YOU WIN");
        }
    }
    void Update()
    {
        if (coutTime >= -1f)
        {
            CountTimeStartGame();
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

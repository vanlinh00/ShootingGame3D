using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    public List<GameObject> _listEnemy;

    void Start()
    {
        instance = this;
    }


    void Update()
    {

    }
    public void DeleteEnemyInList()
    {
        _listEnemy.RemoveAt(_listEnemy.Count - 1);
    }
    public bool CheckListEmty()
    {
        return _listEnemy.Count == 0 ? true : false;
    }
    public void EndGame()
    {
        Time.timeScale = 0;
    }
}

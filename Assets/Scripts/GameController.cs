using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        // AudioController.instance.OnGame();
        //AudioController.instance.CountStartGame();
    }
    public void Start()
    {


    }
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        Cursor.visible = false;
        instance = this;
        AudioController.instance.OnGame();
        AudioController.instance.CountStartGame();
    }
    public void Start()
    {


    }
    void Update()
    {

    }
}

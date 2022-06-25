using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMainCavasGP : MonoBehaviour
{
    [SerializeField] Text _txtCountStartGame;

    float coutTime = 3.2f;
    void Start()
    {

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

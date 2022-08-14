using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour
{
    [SerializeField] TextAsset _textJson;

    [System.Serializable]
    public class Weapon
    {
        public int id;
        public string name;
        public float damage;
        public float accuracy;
        public int priceForCoin;
        public int priceForDiamond;
    }

    [System.Serializable]
    public class listWeapons
    {
        public Weapon[] guns;
        public Weapon[] Knives;
    }

    public listWeapons listGunsOfPlayer = new listWeapons();
    void Start()
    {
        listGunsOfPlayer = JsonUtility.FromJson<listWeapons>(_textJson.text);
    }

}

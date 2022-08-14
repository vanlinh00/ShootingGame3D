using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id { get; set; }
    public string name { get; set; }
    public float damage { get; set; }
    public float rateOfFire { get; set; }
    public float accuracy { get; set; }
    public int priceForCoin { get; set; }
    public int priceForDiamond { get; set; }
}

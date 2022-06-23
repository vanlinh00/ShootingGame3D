using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string id;
    // public float x;
    //public float z;
    public PlayerVector3 position = new PlayerVector3();
    public PlayerVector3 rotation = new PlayerVector3();


}
public class PlayerVector3
{
    public float x;
    public float y;
    public float z;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static InforPlayer inforPlayer;
    static DataPlayer()
    {
        // tranform data from json to inforPlayer
        inforPlayer = JsonUtility.FromJson<InforPlayer>(PlayerPrefs.GetString(ALL_DATA));

        // if all == null  it mean the user logged in for the first time
        // now you need to initialize default value for user

        if (inforPlayer == null)
        {
            var level = 1;

            //inforPlayer = new inforPlayer();
            //inforPlayer.level = level;

            inforPlayer = new InforPlayer
            {
                level = level,
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(inforPlayer);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static void updataLevel()
    {
        inforPlayer = new InforPlayer
        {
            level = inforPlayer.level + 1,
        };
        SaveData();
    }
    public static InforPlayer getInforPlayer()
    {
        return inforPlayer;
    }

}
public class InforPlayer
{
    public int level;
}


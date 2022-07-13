using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform a;
    void Start()
    {
        List<GameObject> arrayListGameObject = new List<GameObject>();

        int arrayCount = this.transform.childCount;

        for (int i = 0; i < arrayCount; i++)
        {
            arrayListGameObject.Add(this.transform.GetChild(i).gameObject);
        }
        foreach (GameObject index in arrayListGameObject)
        {
            index.transform.parent = a;
        }

    }
}

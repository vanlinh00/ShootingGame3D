using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Transform objectA;
    void Start()
    {

    }
    void Update()
    {
        // Lerp di chuyen object dang gan script den object khac
        //  transform.position = Vector3.Lerp(transform.position, objectA.position, 0.2f * Time.deltaTime);

        // phap gan
        // transform.position = transform.position + Vector3.forward;

        //phep gan rotation
        // transform.rotation = Quaternion.Euler(120, 120, 0);
    }
}

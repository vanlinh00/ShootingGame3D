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

        // di chuyen object B theo huong object A
        //  transform.position = transform.position + objectA.position * Time.deltaTime;

        // di chuyen object B theo huong thang
        //  transform.position = transform.position + Vector3.forward;

        // di chuyen object B theo huong thang
        // transform.Translate(transform.forward);

        //di chuyen object B den object A
        // muon di chuyen thang B den A cho translate vao huong tu B den A 
        // transform.Translate((objectA.position - transform.position) * Time.deltaTime);

        // di chuyen object B theo huong A ma khong dung lai
        // transform.Translate(objectA.position);
    }
}

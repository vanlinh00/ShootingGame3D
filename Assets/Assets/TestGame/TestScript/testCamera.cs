using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCamera : MonoBehaviour
{

    // follow
    [SerializeField] GameObject _player;
    Vector3 _offset;
    void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}

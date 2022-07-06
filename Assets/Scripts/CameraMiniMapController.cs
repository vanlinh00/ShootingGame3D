using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMiniMapController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    Vector3 _offset = Vector3.zero;
    void Start()
    {
        _offset = transform.position - _player.transform.position;

    }

    void Update()
    {
        transform.position = _offset + _player.transform.position;

        transform.rotation = Quaternion.Euler(90f, _player.transform.rotation.y, 0f);
    }
}

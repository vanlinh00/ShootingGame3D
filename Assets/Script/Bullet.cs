using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform _firePoint { get; set; }
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        transform.position = Vector3.Lerp(transform.position, _firePoint.position, 400f);
    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        GameController.instance.DeleteEnemyInList();
        if (GameController.instance.CheckListEmty())
        {
            //   GameController.instance.EndGame();
        }

    }
}

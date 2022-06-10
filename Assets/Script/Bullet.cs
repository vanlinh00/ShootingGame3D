using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform _firePoint { get; set; }
    public int _posPlayerShooting { get; set; }
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
        if (GameController.instance._listPlayer.Count > 1 && collision.gameObject.tag.Equals("Player") == true)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameController.instance.DeleteEnemyInList(_posPlayerShooting);

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 _firePoint { get; set; }
    public int _posPlayerShooting { get; set; }

    void Start()
    {

    }
    private void Update()
    {
        //transform.position = transform.position + Vector3.up;
        //    Debug.Log(_firePoint);
        //transform.Translate((_firePoint - transform.position) * 0.01f);
        transform.position = Vector3.Lerp(transform.position, _firePoint, 2f * Time.timeScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Boss"))
        {
            GameObject _particleBullet = Instantiate(Resources.Load("ParticleBullet", typeof(GameObject)), _firePoint, Quaternion.identity) as GameObject;
            collision.gameObject.GetComponent<EnemyController>().muHealp(0.1f);
            Destroy(_particleBullet, 1);

        }
    }
}

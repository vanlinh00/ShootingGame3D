using StarterAssets;
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
        transform.position = Vector3.Lerp(transform.position, _firePoint, 2f * Time.timeScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            GameObject _particleBullet = Instantiate(Resources.Load("ParticleBullet", typeof(GameObject)), _firePoint, Quaternion.identity) as GameObject;
            _particleBullet.transform.parent = collision.gameObject.transform;

            // cach 1 dung ke thua
            //if (collision.gameObject.tag.Equals("Enemy"))
            //{
            //    collision.gameObject.GetComponent<EnemyController>().muHealp(0.1f);
            //}
            //else
            //{
            //    collision.gameObject.GetComponent<ThirdPersonController>().muHealp(0.01f);
            //}

            // cach 2 dung interface
            IDamageable Damage = collision.gameObject.GetComponent<IDamageable>();
            if (Damage != null)
            {
                Damage.Damage();
            }
            Destroy(_particleBullet, 2f);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

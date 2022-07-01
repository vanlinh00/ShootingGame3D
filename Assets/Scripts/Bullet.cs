using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// chi may giay cho bat 1 lan chua ba lien tuc hoi ghe
// nem bom
// khi boss tren con lai cai hom do
// ra nhat co vu khi
// co tu do
// M4  ban vao dau 1 phat di luong
public class Bullet : MonoBehaviour
{
    public Vector3 _firePoint { get; set; }
    public int _posPlayerShooting { get; set; }

    void Start()
    {
        AudioController.instance.AkFire();
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
            Destroy(this.gameObject, 0.5f);
        }
    }
}

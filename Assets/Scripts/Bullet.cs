using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ImoveBulletable
{
    public Vector3 _firePoint { get; set; }

    private float speed = 2f;
    public void Move()
    {
        SoundManager.instance.OnPlayAudio(SoundType.AKFire);
        transform.position = Vector3.Lerp(transform.position, _firePoint, speed * Time.timeScale);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
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

        }

    }

}

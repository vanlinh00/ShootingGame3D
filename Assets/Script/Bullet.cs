using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// chi may giay cho bat 1 lan chua ba lien tuc hoi ghe
// nem bom
// khi boss tren con lai cai hom do
// ra nhat co vu khi
// co tu do
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
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Player"))
        {
            GameObject _particleBullet = Instantiate(Resources.Load("ParticleBullet", typeof(GameObject)), _firePoint, Quaternion.identity) as GameObject;
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyController>().muHealp(0.1f);
            }
            else
            {
                Debug.Log("Enemy ban player");
            }
            Destroy(_particleBullet, 3);
            Destroy(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject, 2);
        }
    }
}

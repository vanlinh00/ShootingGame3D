using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BasePlayerController : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    [SerializeField]
    Transform _posGun;

    protected int health = 10000;

    [SerializeField]
    public Image _healthBar;

    public void PlayerRun()
    {
        _animator.SetBool("shoot", false);
        _animator.SetBool("run", true);

    }
    public void Playershoot()
    {
        _animator.SetBool("shoot", true);
    }
    public void PlayerIdle()
    {
        _animator.SetBool("shoot", false);
        _animator.SetBool("run", false);
    }

    public void AnimatorPlayer(int a)
    {
        switch (a)
        {
            case 0:
                Debug.Log("idle");
                PlayerIdle();
                break;
            case 1:
                Debug.Log("run");
                PlayerRun();
                break;
            case 2:
                Debug.Log("shoot");
                Playershoot();
                break;
            default:
                break;
        }

    }
    protected virtual void Shooting(Vector3 _shootPoint)
    {
        StartCoroutine(ShootingCoroutine(_shootPoint));

        //GameObject _newBullet = Instantiate(Resources.Load("Bullet", typeof(GameObject)), _posGun.position, _posGun.rotation) as GameObject;
        //GameObject _vFX_M4 = Instantiate(Resources.Load("VFX_M4", typeof(GameObject)), _posGun.position, _posGun.rotation) as GameObject;
        //_newBullet.GetComponent<Bullet>()._firePoint = _shootPoint;
        //Destroy(_newBullet, 0.1f);
        //Destroy(_vFX_M4, 1);
    }

    IEnumerator ShootingCoroutine(Vector3 _shootPoint)
    {
        GameObject Bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", _posGun.position, _posGun.rotation);
        Bullet.GetComponent<Bullet>()._firePoint = _shootPoint;

        GameObject _vFX_M4 = ObjectPooler.Instance.SpawnFromPool("VFX_M4", _posGun.position, _posGun.rotation);


        ImoveBulletable moveBullet = Bullet.GetComponent<ImoveBulletable>();
        moveBullet.Move();

        yield return new WaitForSeconds(0.009f);

        Bullet.SetActive(false);
        _vFX_M4.SetActive(false);
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            StartCoroutine(ParticleBloodCoroutine(collision.gameObject.GetComponent<Bullet>()._firePoint));
        }
    }
    IEnumerator ParticleBloodCoroutine(Vector3 _firePoint)
    {

        GameObject particleBlood = ObjectPooler.Instance.SpawnFromPool("ParticleBlood", _firePoint, Quaternion.identity);

        // Blood move Player ou Enemy
        particleBlood.transform.DOMove(transform.position, 1000f);

        yield return new WaitForSeconds(1);

        particleBlood.SetActive(false);

    }


    // co the dung ke thua vi enemy va player deu giong nhau, nhung nen dung interface vi tuong lai se co nhieu thu phai damage vd nhu cai thung
    //public virtual void muHealp(float n)
    //{
    //    
    //    _healthBar.GetComponent<Image>().fillAmount -= n;
    //    health -= 1000;
    //    if (health <= 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

}

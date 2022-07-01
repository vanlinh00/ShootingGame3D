using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasePlayerController : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    [SerializeField]
    Transform _posGun;

    protected int health = 10000;

    [SerializeField]
    public Image _healthBar;
    void Update()
    {

    }
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
    protected void Shooting(Vector3 _shootPoint)
    {
        GameObject _newBullet = Instantiate(Resources.Load("Bullet", typeof(GameObject)), _posGun.position, _posGun.rotation) as GameObject;
        GameObject _vFX_M4 = Instantiate(Resources.Load("VFX_M4", typeof(GameObject)), _posGun.position, _posGun.rotation) as GameObject;
        _newBullet.GetComponent<Bullet>()._firePoint = _shootPoint;
        Destroy(_vFX_M4, 1);
    }

    // co the dung ke thua vi enemy va player deu giong nhau, nhung nen dung interface vi tuong lai se co nhieu thu phai damage vd nhu cai thung
    //public virtual void muHealp(float n)
    //{
    //    UiMainCavasGP.instance.countEnemy();
    //    _healthBar.GetComponent<Image>().fillAmount -= n;
    //    health -= 1000;
    //    if (health <= 0)
    //    {
    //        Destroy(this.gameObject);

    //    }
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasePlayerController : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    [SerializeField]
    Transform _posGun;

    protected int health = 10000;


    void Update()
    {

    }
    protected void AnimationIdleToRun()
    {
        _animator.SetBool("idle", false);
        _animator.SetBool("run", true);
    }
    protected void AnimationRunToIdle()
    {
        _animator.SetBool("idle", true);
        _animator.SetBool("run", false);
    }
    protected void AnimationIdleToShoot()
    {

        _animator.SetBool("idle", false);
        _animator.SetBool("shoot", true);
    }
    protected void AnimationShootToIdle()
    {
        _animator.SetBool("shoot", false);
        _animator.SetBool("idle", true);

    }

    // ideal nay da xoa
    protected void PlayerLookAt()
    {
        int distancePlayerToPlayer = GameController.instance.FindPlayerNear(transform)[0];
        int positionPlayer = GameController.instance.FindPlayerNear(transform)[1];

        if (distancePlayerToPlayer < 20)
        {
            transform.LookAt(GameController.instance._listPlayer[positionPlayer].transform.position);
        }

    }
    protected void Shooting(Vector3 _shootPoint)
    {
        GameObject _newBullet = Instantiate(Resources.Load("Bullet", typeof(GameObject)), _posGun.position, _posGun.rotation) as GameObject;
        _newBullet.GetComponent<Bullet>()._firePoint = _shootPoint;
    }
}

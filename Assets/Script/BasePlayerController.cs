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

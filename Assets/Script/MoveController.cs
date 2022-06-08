using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

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
}

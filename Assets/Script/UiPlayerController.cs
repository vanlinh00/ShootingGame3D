using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPlayerController : MonoBehaviour
{
    public static UiPlayerController instance;
    private Animator _animator;
    void Start()
    {
        instance = this;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerRun()
    {
        _animator.SetBool("run", true);
    }
    public void Playershoot()
    {
        _animator.SetBool("shoot", true);
    }
    void PlayerIdle()
    {
        _animator.SetBool("idle", true);
    }
}

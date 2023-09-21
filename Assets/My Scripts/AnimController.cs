using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimController : MonoBehaviour
{
    private Animator _animator;

    public static bool AttackAnimPlaying = false;

    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            AttackAnimPlaying = true;
        }
        else
        {
            AttackAnimPlaying = false;
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        _animator.Play("Idle");
    }

    public void PlayRun()
    {
        _animator.Play("Run");
    }

    public void PlayAttack() {
        _animator.Play("Attack");
    }
}


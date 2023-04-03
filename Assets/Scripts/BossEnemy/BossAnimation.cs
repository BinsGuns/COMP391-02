using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAnimation : MonoBehaviour
{
    private Animator _animator;
    private BossController _bossController;
    private bool _player;
    // private NavMeshAgent _navMeshAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _bossController = GetComponent<BossController>();
        // _navMeshAgent = GetComponent<NavMeshAgent>();
        _bossController.PlayerOnRadius += WalkAnimationBoss;
        _bossController.OnBossAttackAnimation += AttackAnimationBoss;
    }

    private void AttackAnimationBoss()
    {
        _animator.SetTrigger("Attack");
    }

    private void WalkAnimationBoss(bool isPlayerOnRadius)
    {
        _player = isPlayerOnRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {// walk
            _animator.SetFloat("Speed",1);
        }
        
        
    }
}

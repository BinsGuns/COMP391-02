using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    
    [SerializeField] private Transform _spawnPoint;
    private SpriteRenderer _enemyRender;
    public Action<bool> PlayerOnRadius;
    public Action<GameObject> OnPlayerAttacked;
    public Action<float> OnPlayerTakenDamage;
    public Action<float> OnDamageTaken;
    public Action OnBossAttackAnimation;
    
    // private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    
    private void Start()
    {
        // _navMeshAgent = GetComponent<NavMeshAgent>();
        //PlayerOnRadius += OnPlayerRadius;
        _enemyRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // if (_player)
        // {
        //     _navMeshAgent.isStopped = false;
        //     _navMeshAgent.SetDestination(_player.transform.position);
        //     // look and flip to player
        //     if (_player.transform.position.x < transform.position.x) _enemyRender.flipX = true;
        //     else _enemyRender.flipX = false;
        // }
        // else
        // {
        //     _navMeshAgent.SetDestination(_spawnPoint.position);
        // }
        //
    }

    // private void OnPlayerRadius(bool player)
    // {
    //     _player = player;
//    }
}

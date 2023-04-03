using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossHitBox : MonoBehaviour
{
    //[SerializeField] private float _attackDelay;
    //[SerializeField] private float _attackDuration;
    //[SerializeField] private Collider _hitboxOne;
    private GameObject _boss;

    private BossController _bossController;
    private NavMeshAgent _meshAgent;

    private bool _isAttackingPlayer;

    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _boss = GameObject.FindGameObjectWithTag("Boss");
        _bossController = _boss.GetComponent<BossController>();
        _meshAgent = _boss.GetComponent<NavMeshAgent>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            _bossController.OnBossAttackAnimation?.Invoke();
            _bossController.OnPlayerAttacked?.Invoke(_player);
        }
    }

    
    // private IEnumerator EnableHitBox()
    // {
    //     
    //     yield return new WaitForSeconds(_attackDelay);
    //     _hitboxOne.enabled = true;
    //     yield return  new WaitForSeconds(_attackDuration);
    //     _hitboxOne.enabled = false;
    //    //_bossController.isAttackingPlayer?.Invoke(true);
    // }
    
    // private IEnumerator DisableHitBox()
    // {
    //     yield return new WaitForSeconds(_attackDuration);
    //     _hitboxOne.enabled = false;
    //     //_bossController.isAttackingPlayer?.Invoke(true);
    // }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // _isAttackingPlayer = false;
           _bossController.OnPlayerAttacked?.Invoke(null);
        }
    }
    
    
   
}

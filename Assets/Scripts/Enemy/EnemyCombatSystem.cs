using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatSystem : MonoBehaviour
{
    [SerializeField] private float _attackOneDamage;
    [SerializeField] private float _attackDelay;
    private bool _attackingPlayer = true;
    private EnemyController _enemyController;
    

    // Start is called before the first frame update
    void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }
    
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _attackingPlayer = true;
            StartCoroutine(AttackPlayer());
        }
    
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _attackingPlayer = false;
        }
    }
    
   

    private IEnumerator AttackPlayer()
    {
        while (_attackingPlayer)
        {
            _enemyController.EnemyAttackAnimation?.Invoke();
            _enemyController.OnAttackPlayer?.Invoke(_attackOneDamage);
           yield return new WaitForSeconds(_attackDelay);
        }
        
    }
    
    
}

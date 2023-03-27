using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    private PlayerController _playerController;
    private bool isAttacking;
    private bool damageDone;
    private GameObject _enemy;
    private EnemyController _enemyController;
    private Rigidbody _enemyRigidBody;
    public float attackOneDuration;
    private const float FORCE = 200;

    public float attackOneDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController.isPlayerAttacking += OnPlayerAttack;
        _playerController.OnEnemyHit += OnEnemyHit;
    }

    

    // Update is called once per frame
    void Update()
    {

        if (isAttacking)
        {
            EnableHitBox();
            
            if (_enemyController && !damageDone)
            {
                DamageToEnemy();
                //add force upon hit
                if(_enemy.transform.position.x > transform.position.x) _enemyRigidBody.AddForce(Vector3.right * FORCE,ForceMode.Force);
                else _enemyRigidBody.AddForce(Vector3.left * FORCE,ForceMode.Force);
                
            }
            
            StartCoroutine(DisableHitBox());
        }

        
    }

    private void OnEnemyHit(GameObject enemyObject)
    {
        damageDone = false;
        _enemy = enemyObject;
        _enemyRigidBody = enemyObject.GetComponent<Rigidbody>();
        _enemyController = enemyObject.GetComponent<EnemyController>();
    }

    private void DamageToEnemy()
    {
        _enemyController.OnDamageTaken?.Invoke(attackOneDamage);
        damageDone = true;
    }
    private void EnableHitBox()
    {
       
        _playerController.hitBoxColider.gameObject.SetActive(true);
    }
    
    private IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(attackOneDuration);
        _enemyController = null;
        isAttacking = false;
        _playerController.hitBoxColider.gameObject.SetActive(false);
    }

    
    private void OnPlayerAttack(bool isAttack)
    {
        isAttacking = isAttack;
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private bool isHurt;
    private bool isAttacking;
    private EnemyController _enemyController;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyController = GetComponent<EnemyController>();
        _enemyController.EnemyAttackAnimation += AttackAnimation;
        _enemyController.EnemyHurtAnimation += HurtAnimation;
    }

    private void HurtAnimation()
    {
        isHurt = true;
    }

    private void AttackAnimation()
    {
        isAttacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            _animator.SetTrigger("Attack");
            isAttacking = false;
        }

        if (isHurt)
        {
            _animator.SetTrigger("Hurt");
            isHurt = false;
        }
        
    }
}

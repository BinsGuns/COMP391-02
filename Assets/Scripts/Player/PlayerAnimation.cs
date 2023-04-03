using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;

    private bool _isMoving;
    private bool _isAttacking;
    private bool _isJumping;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _playerController.OnJump += OnPlayerJump;
        _playerController.isPlayerAttacking += OnPlayerAttack;
        _playerController.OnMove += OnPlayerMove;
    }

    private void OnPlayerAttack(bool attack)
    {
        _isAttacking = attack;
    }

    private void OnPlayerMove(bool move)
    {
       
        _isMoving = move;
    }

    private void OnPlayerJump(bool jump)
    {
      
        _isJumping = jump;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttacking)
        {
            _animator.SetTrigger("Attack");
            _isAttacking = false;
        }
        
        if (_isJumping)
        {
            _animator.SetBool("isJumping",true);
        }
        else
        { 
            _animator.SetBool("isJumping",false);
        }
        
        if (_isMoving)
        {
            _animator.SetFloat("Speed", 0.5f); // walk
        }
        else
        {
           
            _animator.SetFloat("Speed", 0); // idle
        }
        
    }
}

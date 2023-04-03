using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkStateMachine : StateMachineBehaviour
{

    private GameObject _player;
    private Rigidbody _rigidbody;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindWithTag("Player");
        _rigidbody = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
       _rigidbody.MovePosition(Vector3.MoveTowards(_rigidbody.position, _player.transform.position, Time.fixedDeltaTime * 8));
       
       if (Vector3.Distance(_player.transform.position, _rigidbody.position) <= 4)
       {
            animator.SetTrigger("Attack");
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombatSystem : MonoBehaviour
{
   [SerializeField] private float _bossAttackDamage;
   [SerializeField] private float _attackDuration;
   [SerializeField] private Collider _hitboxCollider;
   
   private BossController _bossController;
   private bool isAttacking;
   private GameObject _player;
   private void Start()
   {
      _bossController = GetComponent<BossController>();
      _bossController.OnPlayerAttacked += AttackPlayer;
   }

   private void AttackPlayer(GameObject obj)
   {
      _player = obj;
   }

   private void Update()
   {
      
   }
   
   
   // this is called on animation event Attack Boss
   public void GetAttackedPlayer()
   {
      if(!_player) return;
         Debug.Log("TRIGGERED ATTACK");
         _bossController.OnPlayerTakenDamage?.Invoke(_bossAttackDamage);
   }

   // private IEnumerator ToggleHitbox(bool isAttack)
   // {
   //    _hitboxCollider.enabled = false;
   //    yield return new WaitForSeconds(_attackDuration);
   //    _hitboxCollider.enabled = true;
   // }

   // private void OnDrawGizmos()
   // {
   //    if (_hitboxCollider.enabled)
   //    {
   //       Gizmos.color = Color.red;
   //       
   //       Gizmos.DrawCube(_hitboxCollider.transform.position,_hitboxCollider.GetComponent<BoxCollider>().size);
   //    }
   // }
}

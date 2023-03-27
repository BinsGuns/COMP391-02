using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCallback : MonoBehaviour
{
   private PlayerController _playerController;
   private PlayerMovement _playerMovement;
   
   private void Start()
   {
      _playerController = GetComponent<PlayerController>();
      _playerMovement = _playerController.playerMovement;
   }

   //when player WASD and arrow keys
   public void OnMove(InputValue value)
   {
      var val = value.Get<Vector2>();
      _playerMovement.OnPlayerMove(val.x,val.y);
   }

   // when player click left mouse
   public void OnFire()
   {
      Debug.Log("ATTACKING");
      _playerController.isPlayerAttacking?.Invoke(true);
   }
}
